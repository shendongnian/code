    static void Main(string[] args)
            {
    
                Console.WriteLine("1 : Option 1");
                Console.WriteLine("2 : Option 2");
                Console.WriteLine("3 : Option 3");
                Console.WriteLine("4 : Option 4");
                Console.WriteLine("5 : Option 5");
                Console.Write("Please enter your option choice: ");
                
                
                bool correct = true;
    
                while (correct)
                {
                    string choice = Console.ReadLine();
                    int intChoice = int.Parse(choice);
                    switch (intChoice)
                    {
                        case 1:
                            Console.WriteLine("you chose 1");
                            break;
                        case 2:
                            Console.WriteLine("you chose 2");
                            break;
                        case 3:
                            Console.WriteLine("you chose 3");
                            break;
                        case 4:
                            Console.WriteLine("you chose 4");
                            break;
                        case 5:
                            Console.WriteLine("you chose 5");
                            break;
                        default:
                            correct = false;
                            break;
                    }
                }
            }
