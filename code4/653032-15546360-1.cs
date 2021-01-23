    public IEnumerable<string> Iterate([CallerMemberName]string caller = null)
    {
        Console.WriteLine(caller);
        return items;
    }
    foreach (var myItem in items.Iterate())
    {
        //..
    }
