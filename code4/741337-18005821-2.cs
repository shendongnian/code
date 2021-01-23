    using System;
    
    class Program
    {
        static void Main()
        {
            decimal change    = 0.92m;
    
            var coins = new [] {
                new { name = "quarter", nominal   = 0.25m },
                new { name = "dime", nominal      = 0.10m },
                new { name = "nickel", nominal    = 0.05m },
                new { name = "pennies", nominal   = 0.01m }
            };
    
            foreach (var coin in coins)
            {
                int count = (int) (change / coin.nominal);
                change -= count * coin.nominal;
    
                Console.WriteLine("{0} {1}", count, coin.name);
            }
        }
    }
