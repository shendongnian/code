    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Title = "Datetime checker";
                Console.Write("Enter the date and time to launch from: ");
                DateTime time1 = DateTime.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Enter the time to take off: ");
                TimeSpan time2 = TimeSpan.Parse(Console.ReadLine());
                DateTime launch = time1.Subtract(time2);
                Console.WriteLine("The launch time is: {0}", launch.ToString());
                Console.ReadLine();
            }
        }
    }
