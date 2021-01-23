    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace arraypracticeforstring
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] arr = new string[3] { "Snehal", "Janki", "Thakkar" };
    
                foreach (string item in arr)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            }
        }
    }
