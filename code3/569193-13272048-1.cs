    var total = new List<List<string>>() { 
        new List<string>(), 
        new List<string>(), 
        new List<string>(), 
        new List<string>(), 
        new List<string>(), 
        new List<string>() 
    };
    //the statement
    var q = k.Aggregate(total, (listOlists, singleStrin) => {
        listOlists.Where(l => !l.Contains(singleStrin)).First().Add(singleStrin);
        return listOlists;
    });
