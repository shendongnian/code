    bool executeLoop = true;
    while (executeLoop)
    {
        ...
        Console.WriteLine("Again? (Y/N)");
        string input = Console.ReadLine();
        while (input != "N" && input != "Y")
        {
            Console.WriteLine("Invalid answer. Again? (Y/N)");
            input = Console.ReadLine();
        }
        if (input == "N")
        {
            executeLoop = false;
            // can also just write "break;"
        }
    }
