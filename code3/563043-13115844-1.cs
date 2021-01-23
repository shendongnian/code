    {
      IEnumerator<?> e = ((IEnumerable<?>)Model).GetEnumerator();
      try
      { 
        int m;  // this is inside the loop in C# 5
        while(e.MoveNext())
        {
          m = (?)e.Current;
          // your code goes here
        }
      }
      finally
      { 
        if (e != null) ((IDisposable)e).Dispose();
      }
    }
