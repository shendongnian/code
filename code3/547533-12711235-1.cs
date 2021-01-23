    string answerToUniverse = "42";
    object caster = answerToUniverse;
    if (caster is int)
    {
        Console.WriteLine("It's an integer!");
    }
    else
    {
        Console.WriteLine("It's NOT an integer!");
    }
