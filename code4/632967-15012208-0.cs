    using System;
    namespace week0502
    {
       class Interest
       {
          static void Main(string[] args)
          {
             decimal p = 0; // principle
             decimal r = 1; // interest rate
             decimal t = 2; // time/years entered
             decimal i = 3; // interest
             decimal a = 4; // new amount
             // prompt for values
             Console.Write("Enter original deposit amount: ");
             p = Convert.ToDecimal(Console.ReadLine());
             Console.Write("Enter annual interest rate (10% as 10): ");
             r = Convert.ToDecimal(Console.ReadLine());
             Console.Write("Enter years to save this deposit amount: ");
             t = Convert.ToDecimal(Console.ReadLine());
             Console.WriteLine();
             // display headers
             Console.WriteLine("Year Rate Amount  Interest  New Amount");
             // calculate new amount on deposit after t amount of years
             for (int n = 1; n <= t; n++)
             {
                   // calculations
                   i = p * r;
                   a = i + p;
                   // display contents
                   Console.WriteLine("{0, 4}{1, 4}{2, 10:C}{3, 5}{4, 10:C}", n, r, p, i, a);
                } // end for
             Console.ReadLine(); //Add this to prevent application from closing
          } // end main
       } // end class
    } 
