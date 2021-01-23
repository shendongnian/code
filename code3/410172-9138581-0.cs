    // reference method
    static string Foo(string text, World world, Player player)
    {
        string output = SomeClass.PrintStarting();
        if (SomeClass.Exists(text, world, player))
        {
            output += SomeClass.PrintName(text, world, player);
            SomeClass.KillPlayer(text, world, player);
            if (SomeClass.Exists(text, world, player))
                output += SomeClass.PrintSurvived(text, world, player);
        }
        else
            output += SomeClass.PrintNotExists(text, world, player);
        return output;
    }
