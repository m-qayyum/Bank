/* In this Program we are taking inputs from user to help balance the bank account by using methods.
 * 
 * Variable Names:
 * bonus (Defined as double floating point point and is taken constant by defining value of 0.01 i.e. 1% to it),
 * Transaction (Variable to define transaction type and this is defined as a character),
 * Bal (Defined as double to display total money/balance in the account),
 * Amount (Defined as double to calculate changes happening in account and update the balance of account).
 */

using System;

namespace Bank
{
    class Program
    {
        // Defining bonus as double constant floating point number with value of 0.01 i.e. 1%.
        const double bonus = 0.01;

        // Main Method.
        static void Main()
        {
            // Defining Different Variables which we are gonna use in Program.
            Char Transaction = '\t';
            double Bal = 0, Amount = 0;

            // Giving user a set of valid transaction types so he avoid making mistake and if he does next time he will be aware of it.
            Console.WriteLine("Valid Transactions are: \n W/w = Withdrawal \n D/d = Deposit \n P/p = Print \n Q/q = Quit");

            // Do While Loop to keep track of transaction type user is entering.
            do
            {
                // Prompt the user.
                Console.Write("Enter one of the valid Transaction type: ");
                Transaction = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                // Switch statement to choose an appropriate Transaction type.
                switch (Transaction)
                {
                    // Depositing the Money.
                    case 'D':
                        Amount = GetAmount(Transaction);
                        Deposit(Amount, ref Bal);
                        break;

                    // Withdrawal of Money.
                    case 'W':
                        Amount = GetAmount(Transaction);
                        Withdrawal(Amount, ref Bal);
                        break;

                    // Print Current Balance.
                    case 'P':
                        Print(Bal);
                        break;

                    //Quit.
                    case 'Q':

                        //Message for user when leaves the program.
                        Console.WriteLine("See You Soon!");
                        break;

                    // Error.
                    default:
                        // Error Message for user.
                        Console.WriteLine("ERROR! Enter a Valid Transaction.");
                        break;
                }

            } while (Transaction != 'Q');

            Console.Read();
        }

        // Defined Method # 1 (Get Amount) which returns a non-negative value representing the amount of a deposit or withdrawal.
        public static double GetAmount(double amount)
        {
            do
            {
                Console.Write("Enter a non-negative Amount: ");
                amount = Convert.ToDouble(Console.ReadLine());
            } while (amount < 0);
            return amount;

        }

        // Defined Method # 2 (Withdrawal).
        public static void Withdrawal(double amount, ref double balance)
        {
            // If-Else Loop is used so the balance does not go in negative and the customer will also be warned.
            if (balance > amount + 1.5)
            {
                // $1.50 service charges are applied to each withdrawal.
                balance = balance - (amount + 1.5);
            }
            else
                Console.WriteLine("Transaction Failed (Low Balance={0:C})", balance);
            return;
        }

        // Defined Method # 3 (Deposit).
        public static void Deposit(double amount, ref double balance)
        {
            // Customer receives a 1% bonus for amount greater than or equal to 2000.
            if (amount >= 2000)
            {
                balance += amount + (amount * bonus);
            }
            // If the amount is less than 2000 than no bonus.
            else
                balance += amount;
            return;
        }

        // Defined Method # 4 (Print) which displays/prints the current balance in the account.
        public static void Print(double balance)
        {
            Console.WriteLine("Current Balance: {0:C}", balance);
            return;
        }
    }
}