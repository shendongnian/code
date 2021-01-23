    List<string> s = new List<string>();
    s.Add("1");
    s.Add("2");
    s.Add("3");
    s.Add("4");
    
    FieldInfo info = s.GetType().GetField("_items", BindingFlags.Instance | BindingFlags.NonPublic);
    string[] items = (string[])info.GetValue(s);
    
    for (int i =  0; i < s.Count; i++) {
      Console.WriteLine(items[i]);
    }
