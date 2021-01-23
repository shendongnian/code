    int num1, num2; 
    char oPt;
    string Count;
    do
    {
        Console.WriteLine("Enter 1st Value");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter 2nd Value : ");
        num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(" + - * / ");
        oPt = Convert.ToChar(Console.ReadLine());
        if (oPt == '-')
        {
            Console.WriteLine("Result: " + (num1 - num2));
        }
        else if (oPt == '+')
        {
            Console.WriteLine("Result: " + (num1 + num2));
        }
        else if (oPt == '*')
        {
            Console.WriteLine("Result: " + (num1 * num2));
        }
        else if (oPt == '/')
        {
            Console.WriteLine("Result: " + (num1 / num2));
        }
        do
        {
            Console.WriteLine("Do you wish to calculate another? Yes (y) or No (n): ");
            Count = Console.ReadLine();
            var CountLower = Count?.ToLower();
            if ((CountLower == "y") || (CountLower == "n"))
                break;
            } while (true );
        } while (Count != "n");
    } 
