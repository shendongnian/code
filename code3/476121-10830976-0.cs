    public void MyMethod(List<ISomeInterface> entityList)
    {
      foreach(var entity in entityList)
      {
        dynamic obj = entity;
        ProcessEntity(obj);
      }
    }
