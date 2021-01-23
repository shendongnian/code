    if(IsPost){
    var Pinsimg = "gmarker.png";    
    var temp = Request["areaId"].Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries).ToList();
    
        var parms = temp.Select((s, i) => "@" + i.ToString()).ToArray();
    
        var inclause = string.Join(",", parms); 
    
        var extraplaceholder = "@" + temp.Count();
    
        temp.Add(Pinsimg.ToString());
    
           categories = db.Query(String.Format("SELECT address, id, areaid, pinsimg FROM tblproperty WHERE areaId IN ({0}) and pinsimg = {1}", inclause, extraplaceholder), temp.ToArray());
    }
