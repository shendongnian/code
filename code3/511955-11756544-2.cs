    IDisposable disp = new IDisposable();
    
    try
    {
      //some logic here
    }
    finally
    {
      if (disp != null)
         ((IDisposable)disp).Dispose();
    }
