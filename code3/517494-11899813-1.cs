    using System;
    public static class Program
    {
        static void Main()
        {
            const int addition = 0;
            const int subtraction = 1;
            const int multiplication = 2;
            
            var a = GetInt32("Enter the value of a:");  
            var b = GetInt32("Enter the value of b:");
    choose:        
            var choice = GetInt32(string.Format(@"Enter your choice:
                {0}: Addition
                {1}: Subtraction
                {2}: Multiplication", addition, subtraction, multiplication));  
            switch(choice)
            {
                case addition:
                    {
                        Console.WriteLine("Addition value is :{0}", a + b);
                        break;
                    }
                case subtraction:
                    {
                        Console.WriteLine("Subtraction value is :{0}", a - b);
                        break;
                    }
                case multiplication:
                    {
                        Console.WriteLine("Multiplication value is :{0}", a * b);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice ");
                        goto choose; 
                    }
            }
        }
        
        private static int GetInt32(string prompt)
        {
            while(true)
            {
                Console.WriteLine(prompt);
                var line = Console.ReadLine();
                int result;
                if(int.TryParse(line, out result))
                    return result;
            }
        }
    }
