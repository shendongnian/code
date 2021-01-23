    var alist = GetPartAWidgets().OrderBy(w => w.ID);
    var blist = GetPartBWidgets().OrderBy(w => w.ID);
    var merged = alist.Zip(blist, (a,b) => new Widget()
                 {
                   ID = a.ID,
                   Name = string.IsNullOrEmpty(a.Name) ? b.Name : a.Name,
                   //etc. 
                 });
