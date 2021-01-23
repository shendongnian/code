    IDisposable x = null;
    try
    {
         x= new X();
         //inside the using
         return x.Value;
    }
    finally
    {
         if(x != null)
            x.Dispose();
    }
