    var count = datamodel.Compliances.Local.Count; // number of items in cache (ex. 30)
    datamodel.Compliances.Local.ToList().ForEach(c => {
	    datamodel.Entry(c).State = EntityState.Detached;
    });
    count = datamodel.Compliances.Local.Count; // 0
