    var slots = new List<Tuple<DateTime, DateTime>>();
    DateTime start = new DateTime(2012, 2, 28);
    DateTime end = new DateTime(2012, 3, 6);
    for (DateTime i = start; i < end; i = i.AddDays(7))
    {
        slots.Add(new Tuple<DateTime, DateTime>(i, i.AddDays(6)));
    }
    
    foreach (var slot in slots)
    {
        Console.WriteLine("{0}\t{0}", slot.Item1.ToString("dd/MM/yyyy"), slot.Item2.ToString("dd/MM/yyyy"));
    }
