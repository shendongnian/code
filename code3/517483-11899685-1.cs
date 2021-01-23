    static void Main(string[] args) 
    { 
        int a,b,ch; 
        while (true)
        { 
            // GET READY TO ASK THE USER AGAIN
            Console.Clear();
            Console.WriteLine("Enter the value of a:"); 
            a = Convert.ToInt32(Console.ReadLine());    
 
            Console.WriteLine("Enter the value of b:"); 
            b = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Enter your choice : Addition:0  Subtraction:1  Multiplication :2 :"); 
            ch = Convert.ToInt32(Console.ReadLine()); 
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
