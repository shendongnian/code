    string num = "32";
    object caster = num;
    if (caster is int)
    {
        Console.WriteLine("It's an integer!");
    }
    else
    {
        Console.WriteLine("It's NOT an integer!");
    }
