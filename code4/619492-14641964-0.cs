    int nameCount = 0;
    int contactCount = 0;
    int friendCount = 0;
    
    Main.GroupBy(x => x.Parent).ToDictionary(pair => pair.Key, pair => {
       nameCount += pair.Count(y => y.Name);
      //etc. for the rest of the counters.
    }
