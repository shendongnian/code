    int a = 0, b = 0, ch = 1; //always initialize your variables.
    
    Console.WriteLine("Enter the value of a:");
    a = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Enter the value of b:");
    b = Convert.ToInt32(Console.ReadLine()); 
    while (ch != 4) //starts at -1 so it will surely enter the loop
    {
        //Will keep asking until user enters "4", then it will exit
        Console.WriteLine("Enter your choice : Addition:0  Subtraction:1  Multiplication :2 :");
        ch = Convert.ToInt32(Console.ReadLine());
    
        switch (ch)
        {
            case 0:
                {
                    Console.WriteLine("Addition value is :{0}", a + b);
    
                } break;
            case 1:
                {
                    Console.WriteLine("Subtraction value is :{0}", a - b);
    
                } break;
            case 2:
                {
                    Console.WriteLine("Multiplication value is :{0}", a * b);
    
                } break;
            // case 4 is not needed, it will exit from the loop anyway
            default:
                {
                    Console.WriteLine("Invalid choice");
                } break;
        }
    }
