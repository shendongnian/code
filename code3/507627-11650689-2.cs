    public void checkResponse(string response, string confirmValue)
    {
    Check:
        Console.WriteLine(response);
        Console.WriteLine(response);
        if (response == "Y")
        {
            return;
        }
        else if (response == "N")
        {
            Environment.Exit(0);
        }
        else
        {
            while ((response != "Y") && (response != "N"))
            {
                Console.Clear();
                Console.WriteLine("\"" + response + "\" is not a valid response.");
                Console.WriteLine();
                Console.WriteLine("You entered:" + confirmValue);
                Console.WriteLine("Is this correct? (Y/N)");
                response = Console.ReadLine().ToUpper();
            }
            goto Check;
        }
    }
