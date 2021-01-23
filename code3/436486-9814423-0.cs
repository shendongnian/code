    var smaps = new List<SheetMappings>(); 
    foreach(maplist m in mlist) 
    {
        var pi = typeof(vallist).GetProperty(m.ColumnName);
        var newMap = new SheetMappings(); 
 
        foreach(vallist v in vlist) 
        {
            newMap.Value = pi.GetValue(v, null); 
            newMap.xCord = m.xCord; 
            newMap.yCord = m.yCord; 
        } 
        smaps.Add(newMap); 
    } 
