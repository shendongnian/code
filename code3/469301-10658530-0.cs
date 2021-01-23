    {
      MapDataContainer ent = new MapDataContainer();
      try
      {
        ...
      }
      finally
      {
        if (ent != null)
          ((IDisposable)ent).Dispose();
      }
    }
