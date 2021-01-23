    var list = new List<string>();
    ...
    if (Cache["Key1"] == null)
     { 
          Cache.Insert("Key1", list, null, DateTime.Now.AddMinutes(2), Cache.NoSlidingExpiration);
     }
