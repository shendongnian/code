    public T Update(T poco)
    {
      //get the entity from db
      T proxyPoco = context.Set<T>().Find(id);
      //alternatively just create the proxy, set the id and attach.
      //no db retrieval.
      //T proxyPoco = context.Set<T>.Create();
      //proxyPoco.Id = poco.Id;
      //context.Set<T>.Attach(proxyPoco);
    
      if(proxyPoco == null) 
      {
        //throw an exception or handle case where the entity is not found.
        //unecessary if using alternative above.
      }
      else 
      {
        //set the proxy poco values using your original poco
        context.Entry<T>(proxyPoco).CurrentValues.SetValues(poco);
      }
      context.SaveChanges();
      return proxyPoco;
    }
