    List<float> a = new List<float>();
    a.Add(1.0f);
    a.Add(2.0f);
    
    string fmt = "{0} ft. {1} in.";
    Console.WriteLine(String.Format(fmt, a.Cast<object>().ToArray()));
