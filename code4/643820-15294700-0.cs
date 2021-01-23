    List<myObject> objects = GetObjectsFromApiCall().ToList();
    
    foreach(var obj in objects.Where(o => string.IsNullOrEmpty(objects.SubObject.Title)).ToList())
    {
        var subObject = GetSubObjectFromDatabase(obj.SubObject.Id);
        if(subObject == null) continue;
    
        obj.SubObject.Title = subObject.Title;
    }
