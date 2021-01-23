    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication273
    {
        class Program
        {
            static void Main(string[] args)
            {
                decimal change    = 0.92m;
    
                decimal quarter   = 0.25m;
                decimal dime      = 0.10m;
                decimal nickel    = 0.05m;
                decimal pennies   = 0.01m;
    
                decimal anQuarter = (int)(change    / quarter);
                decimal anDime    = (int)((change   % quarter)  / dime);
                decimal anNickel  = (int)(((change  % quarter)  % dime)  / nickel);
                decimal anPennies = (int)((((change % quarter)  % dime)  % nickel)  / pennies);
    
                Console.WriteLine("The amount of quarters are....{0}", anQuarter);
                Console.WriteLine("The amount of dimes are.......{0}", anDime);
                Console.WriteLine("The amount of nickels are.....{0}", anNickel);
                Console.WriteLine("The amount of pennies are.....{0}", anPennies);
            }
        }
    }
