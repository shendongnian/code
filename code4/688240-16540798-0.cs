    var groups = from n in lstmrks
                 group n by n.StudentName;
    foreach (var g in groups)
    {
        foreach (var s in g)
            Console.WriteLine("{0}\t{1}\t{2}", s.StudentName, s.Total, s.Percentage);
        Console.WriteLine("-----------------");
        Console.WriteLine("{0}\t{1}\t{2}", g.Key, g.Sum(x => x.Total), g.Average(x => x.Percentage));
        Console.WriteLine("-----------------");
    }
