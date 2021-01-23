        static void Main(string[] args)
        {
            int firstValue, secondValue, arithmeticOperation;
        RestartProgram:
            Console.WriteLine("Enter the value of a:");
            firstValue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the value of b:");
            secondValue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your choice : Addition:0  Subtraction:1  Multiplication :2 :");
            arithmeticOperation = Convert.ToInt32(Console.ReadLine());
            switch (arithmeticOperation)
            {
                case 0:
                    {
                        Console.WriteLine("Addition value is :{0}", firstValue + secondValue);
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("Subtraction value is :{0}", firstValue - secondValue);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Multiplication value is :{0}", firstValue * secondValue);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice ");
                        goto RestartProgram;
                    }
            }
            Console.ReadLine();
        }
