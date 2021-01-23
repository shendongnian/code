    static void Input()
    {
        ConsoleKey key;
        do
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            myObj.bottle(name);            
            do
            {
                Console.WriteLine("Want to enter more name(Y/N)? ");
                key = Console.ReadKey().Key;
            } while (key != ConsoleKey.Y && key != ConsoleKey.N);
        } while (key == ConsoleKey.Y);
    }
