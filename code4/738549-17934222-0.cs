    EntityType myEntity = null;
    if(newItem)
    {
       context.TableName.Add(myEntity = new EntityType());
    }
    else
    {
      myEntity = context.TableName.Where(item => item.PrimaryKey == key).Single();
    }   
    
    context.SaveChanges();
