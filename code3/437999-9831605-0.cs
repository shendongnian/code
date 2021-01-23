    var totals = students.GroupBy(s => s.Name).Select(g => new { Name = g.Key, TotalMissed = g.Sum(s => s.ClassesMissedToday) });
    foreach (var u in totals)
    {
        Console.WriteLine(String.Format("Total classes missed today for {0} is {1}", u.Name, u.TotalMissed));
    }
