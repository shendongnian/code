    ArrayList items = new ArrayList();
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
    IEnumerator myEnumerator = items.GetEnumerator();
    myEnumerator.MoveNext(); // skip the first row
    while (myEnumerator.MoveNext())
    {
        Console.WriteLine(myEnumerator.Current);
    }
