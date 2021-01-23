    Dictionary<string, int> same = new Dictionary<string, int>();
    foreach (string line in lines)
    {
          if (same.ContainsKey(line))
              ++same[line];
          else
              same.Add(line, 1);
                    
          //......
          //do your other stuff
    }
