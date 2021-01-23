    public T Update(T poco)
    {
      //get the entity from db
      T proxyPoco = context.Set<T>().Find(id); 
    
      if(proxyPoco == null) 
      {
        //throw an exception or handle case where the entity is not found
      }
      else 
      {
        //set the proxy poco values using your original poco
        context.Entry<T>(proxyPoco).CurrentValues.SetValues(poco);
      }
      context.SaveChanges();
      return proxyPoco;
    }
