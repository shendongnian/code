    readonly Dictionary<string, int> _dict = new Dictionary<string, int>();
    void InsertOrUpdate(string name, int count)
    {
        int previousCount = 0;
        // item already in dictionary?
        if (_dict.TryGetValue(name, out previousCount))
        {
            // add to count
            count += previousCount;
        }
        _dict[name] = count;
    }
    void Main()
    {
        InsertOrUpdate("pencil", 3);
        InsertOrUpdate("eraser", 3);
        InsertOrUpdate("pencil", 4);
        // print them
        foreach (var item in _dict)
            Console.WriteLine(item.Key + " " + item.Value);
    }
     
