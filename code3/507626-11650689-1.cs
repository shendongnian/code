    public void checkResponse(string response, string confirmValue)
    {
        Console.WriteLine(response);
        Console.WriteLine(response);
            while ((response != "Y") && (response != "N"))
            {
                Console.Clear();
                Console.WriteLine("\"" + response + "\" is not a valid response.");
                Console.WriteLine();
                Console.WriteLine("You entered:" + confirmValue);
                Console.WriteLine("Is this correct? (Y/N)");
                response = Console.ReadLine().ToUpper();
            }
        if (response == "N")
            Environment.Exit(0);
    }
