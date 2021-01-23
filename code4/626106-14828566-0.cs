    List<dynamic> allObjects = new List<dynamic>() { 
        new ObjectOfSomeKind{ ID = 1}, new ObjectOfSomeKind { ID = 2 }};
    List<dynamic> objects = new List<dynamic>();
    
    for (int i = 0; i < ids.Count(); i++)
    {
        int id = ids.ElementAt(i);
        dynamic obj = allObjects.Where(item => item.ID.Equals(id)).SingleOrDefault();
        if (obj == null)                
            throw new Exception("error");                
    
        objects.Add(obj);
    }
