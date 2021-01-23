    List<string> strings = new List<string>() {"asdf", "sdf-sd", "sdfsdf"};
    
    for (int i = strings.Count-1; i > 0; i--)
    {
       if (strings[i].Contains("-"))
       {
           strings.Remove(strings[i]);
       }
    }
