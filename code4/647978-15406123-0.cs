    void Main()
    {
        List<string> list1 = new List<string>();
        List<string> list2 = new List<string>();
        List<string> list3 = new List<string>();
        
        list1.Add("a");
        list1.Add("b");
        list1.Add("c");
        
        list2.Add("d");
        list2.Add("e");
        list2.Add("f");
        
        list3.Add("g");
        list3.Add("h");
        list3.Add("i");
        
        Merge(new[] { list1, list2, list3}, (c1, c2) => c1 + c2).SelectMany(s => s).Dump();
    }
    
    IEnumerable<T> Merge<T>(IEnumerable<IEnumerable<T>> sources, Func<T, T, T> combine)
    {
        return sources.Aggregate((s1, s2) => s1.Zip(s2, combine));
    }
