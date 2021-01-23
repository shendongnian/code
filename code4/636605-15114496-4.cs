    {
      IEnumerator<string> e = ((IEnumerable<string>)new List<string>(){"pass1", "pass2", "pass3" }).GetEnumerator();
       try
       { 
         string pass; // OUTSIDE THE ACTUAL LOOP
          while(e.MoveNext())
          {
            pass = (string)e.Current;
            x = pass;
          }
       }
       finally
       { 
          if (e != null) ((IDisposable)e).Dispose();
       }
    }
