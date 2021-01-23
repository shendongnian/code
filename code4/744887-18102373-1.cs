    var items = new List<string>();
    using (FileStream fs = new FileStream("Scheduler.txt", FileMode.Open, FileAccess.Read))
    using (StreamReader filereader = new StreamReader(fs))
    {
        string linevalue = string.Empty;
        while ((linevalue = filereader.ReadLine()) != null)
        {
            items.Add(linevalue);
        }
    }
    Console.WriteLine(items[0]);
    items.Sort(1, items.Count - 1, StringComparer.CurrentCulture);
    foreach (string str in items)
    {
        Console.WriteLine(str);
    }
