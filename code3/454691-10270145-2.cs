     {
        IEnumerator<int> e = ((IEnumerable<int>)values).GetEnumerator();
        try
        { 
          int m; // OUTSIDE THE ACTUAL LOOP
          while(e.MoveNext())
          {
            m = (int)(int)e.Current;
            funcs.Add(()=>m);
          }
        }
        finally
        { 
          if (e != null) ((IDisposable)e).Dispose();
        }
      }
