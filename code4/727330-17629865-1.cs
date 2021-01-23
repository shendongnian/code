    static void EnterNames()
    {        
        do
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            myObj.bottle(name);            
        } 
        while (WantToEnterMore());
    }
    static bool WantToEnterMore()
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
