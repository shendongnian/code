    foreach (var mwa in GetTierTree())
    {
        Console.WriteLine(mwa.Mission.Name);
        foreach (var awe in mwa.Activities)
        {
            Console.WriteLine("    " + awe.Activity.Name);
            foreach(var e in awe.Events)
                Console.WriteLine("        " + e.Name);
        }
    }
