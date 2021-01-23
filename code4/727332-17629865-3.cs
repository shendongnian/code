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
        ConsoleKey key;
        do
        {            
            Console.WriteLine("Want to enter more name(Y/N)? ");
            key = Console.ReadKey().Key;
        } 
        while (key != ConsoleKey.Y && key != ConsoleKey.N);
        return key == ConsoleKey.Y;
    }
