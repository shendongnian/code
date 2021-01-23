    var ids = new int[]{ ... }; 
    // if ids is null or ids.Length == 0 please return null or an empty list, 
    //do not go further otherwise you'll get Relays without any function filter
    
    var query = Relays.AsQueryable(); 
    foreach (var id in ids)    
    {
         var tempId = id;
         query = query.Where(r=>r.RelayConfigs.Any(rc=>rc.ProtFuncID == tempId)); 
    }
    var items  = query.ToList();
