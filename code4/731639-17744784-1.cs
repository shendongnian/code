      JsonSerializer js = new JsonSerializer();
      var baseEntity = js.Deserialize<BaseEntity>()
      switch(baseEntity.EntityType)
      {
          case EntityOne:
             var result= js.Deserialize<EntityOne>();
             //DoSomeThing
          break; 
          case EntityTwo:
             var result= js.Deserialize<EntityTwo>();
             //DoSomeThing
          break; 
      }
