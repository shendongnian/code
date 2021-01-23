    string[] a = null;
    string[] b = null;
    Dictionary<string, string> values = new Dictionary<string, string>();
    foreach (string s in a)
    {
        values.Add(s, s);
    }
    
    foreach (string s in b)
    {
        values.Remove(s);
    }
    
    foreach (string s in values.Keys)
    {
        Console.WriteLine(s);//This string is in 'a' and not in 'b'
    }
