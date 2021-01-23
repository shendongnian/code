    hitchance = rand.Next(0, 100);
    if (hitchance > 30)
    {
        attackdamage = CH.GetMonsterDamage(rand);
        Console.WriteLine("The Monster Attacks!");
        if (battlechoice == "d" || battlechoice == "D")
        { //this is so that defend has some sort of benefit
            attackdamage /= 2;
        }
        heroHitPoints -= attackdamage;//subtract the damage
        Console.WriteLine("The Hero loses {0}hp", attackdamage);
    }
    else
    {
        Console.WriteLine("The monster misses!");
    }
