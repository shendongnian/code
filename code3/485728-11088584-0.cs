    DataTable dtCSVMultiSCOPassive = new DataTable();
    
    var query = tblGroupedMultiPassive.Where(grp => grp.Count() > 1).SelectMany(grp => grp);
    
    if(query.Any())
    {
        dtCSVMultiSCOPassive = query.CopyToDataTable();
    }
