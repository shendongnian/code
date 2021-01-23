    while (true)
    {
        var inputCharacter = Console.ReadKey().KeyChar;
        if (inputCharacter == '!')
        {
            break;
        }
        if (char.IsLower(inputCharacter))
        {
            Console.WriteLine("OK");
        }
        else
        {
            Console.WriteLine("The character is not a lowercase letter.");
        }
    }
