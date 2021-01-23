    int currentId = 0;
    Entity myEntity = null;
    
    while(dr.Read())
    {
      if(currentId != (int)dr[0])
      {
        currentId = (int)dr[0];
        myEntity = new Entity();
        ...
      }
      myEntity.Properties.Add(new Property() {
        ...
      }
    }
    
