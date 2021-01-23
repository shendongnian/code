    try
    { 
      while(e.MoveNext())
      {
        int m; // INSIDE
        m = (int)(int)e.Current;
        funcs.Add(()=>m);
      }
