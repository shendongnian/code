    Dictionary<int, string> dic1 = new Dictionary<int, string>();
    dic1.Add(1, "One");
    dic1.Add(2, "Two");
    dic1.Add(3, "Three");
    dic1.Add(4, "Four");
    dic1.Add(5, "Five");
    
    Dictionary<int, string> dic2 = new Dictionary<int, string>();
    dic2.Add(5, "Five");
    dic2.Add(6, "Six");
    dic2.Add(7, "Seven");
    dic2.Add(8, "Eight");
    
    Dictionary<int, string> dic3 = new Dictionary<int, string>();
    dic3 = dic1.Union(dic2).ToDictionary(s => s.Key, s => s.Value);
