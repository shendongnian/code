    Dictionary<..> d = new Dictionary<..>()
    foreach(var el in list){
        d[el.PreceedingID] = el; //put data to dict by PreecedingID
    }
    List<..> result = new List<..>();
    int prec = 0; //get first ID
    for(int i = 0; i < list.Length; ++i){
        var actEl = d[prec]; //get next element
        prec = actEl.ID; //change prec id
        result.Add(actEl); //put element into result list
    }
