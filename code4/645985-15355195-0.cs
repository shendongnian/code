    using System;
    
    class Test
    {
        static void Main()
        {
            ShowInterest(4m);    // 4
            ShowInterest(4.0m);  // 4
            ShowInterest(4.00m); // 4
            ShowInterest(4.1m);  // 4.1
            ShowInterest(4.10m); // 4.10
            ShowInterest(4.12m); // 4.12
        }
        
        static void ShowInterest(decimal interest)
        {
            Console.WriteLine(interest.ToString("0.#####"));
        }
    }
