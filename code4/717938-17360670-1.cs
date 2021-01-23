    void PerhapsDoSomething(string input, Func<string, bool> predicate)
    {
        if (predicate(input))
        {
            Console.WriteLine("I did something.");
        }
    }
