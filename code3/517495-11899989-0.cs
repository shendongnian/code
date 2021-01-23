        static void Main(string[] args)
        {
            int a, b, ch;
            Console.WriteLine("Enter the value of a:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the value of b:");
            b = Convert.ToInt32(Console.ReadLine());
            start:
            Console.WriteLine("Enter your choice : Addition:0  Subtraction:1  Multiplication :2 :");
            
            ch = Convert.ToInt32(Console.ReadLine());
            
            switch (ch)
            {
                case 0: Console.WriteLine("Addition value is :{0}", a + b);
                    break;
                case 1: Console.WriteLine("Subtraction value is :{0}", a - b);
                    break;
                case 2: Console.WriteLine("Multiplication value is :{0}", a * b);
                    break;
                default: Console.WriteLine("Invalid choice ");
                    ch = 0;
                    goto start;
            }
        }
