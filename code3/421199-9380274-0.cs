    public DisposableObject Create() 
    {
      DisposableObject entity = new DisposableEntity();
      try 
      {
        //Some operations involving entity
      }
      catch
      {
        entity.Dispose();
        throw;
      }
    }
