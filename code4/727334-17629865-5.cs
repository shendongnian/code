    static void EnterNames()
    {        
        do
        {
           EnterName();
        } 
        while (WantToEnterMoreNames());
    }
    static void EnterName()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();
        myObj.bottle(name);   
    }
    static bool WantToEnterMoreNames()
    {        
        do
        {            
            Console.WriteLine("Want to enter more name(Y/N)? ");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Y: return true;
                case ConsoleKey.N: return false;
                default:
                    continue;
            }
        } 
        while (true);
    }
