    var list = typeof(Math).GetMembers();
    List<string> names = new List<string>();
    var l = list.Select(c => c.Name).ToList().Distinct();
    for (int i = 0; i < l.Count(); i++)
        Console.WriteLine(l.ElementAt(i));
    Console.ReadLine();
