    void Main()
    {
        List<int> items = new List<int>();
        
        items = Enumerable.Range(0, 1000000).ToList();
    
        CopyWithToList(items);
        CopyWithForeach(items);
    
    }
    
    public void CopyWithToList<T>(List<T> list) 
    {
        var sw = Stopwatch.StartNew();
        List<T> copy = list.ToList();
        sw.Stop();
        Console.WriteLine("CopyWithToList: {0}", sw.Elapsed);
    }
    
    public void CopyWithForeach<T>(List<T> list)
    {
        var sw = Stopwatch.StartNew();
        List<T> copy = new List<T>();
        foreach (T item in list) {
            copy.Add(item);
        }
        sw.Stop();
        
        Console.WriteLine("CopyWithForeach: {0}", sw.Elapsed);
    }
