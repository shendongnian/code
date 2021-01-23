    static void Main(string[] args) 
    { 
        int a,b,ch; 
        while (ch != 4)
        { 
            // GET READY TO ASK THE USER AGAIN
            Console.Clear();
            a = GetIntegerInput("Enter the value of a:");
            b = GetIntegerInput("Enter the value of b:");
            ch = GetIntegerInput("Enter your choice : Addition:0  Subtraction:1  Multiplication :2 :");
            switch(ch) 
            { 
                case 0:
                { 
                    Console.WriteLine("Addition value is :{0}", a + b); 
                    break; 
                } 
                case 1: 
                { 
                    Console.WriteLine("Subtraction value is :{0}", a - b); 
                    break; 
                } 
                case 2: 
                { 
                    Console.WriteLine("Multiplication value is :{0}", a * b); 
                    break; 
                } 
                default: 
                { 
                    Console.WriteLine("Invalid choice "); 
                    // THIS GOES TO THE BEGINNING OF THE LOOP
                    // SO THAT YOU CAN ASK THE USER AGAIN FOR
                    // MORE CORRECT INPUT
                    continue;
                }
            }
            // THIS WILL BREAK YOU OUT OF THE LOOP ON A GOOD ENTRY
            break;
        }
    }
