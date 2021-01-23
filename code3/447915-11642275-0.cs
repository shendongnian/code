    var db = new DataContext();
    db.GetChangeSet().Updates.ForEach(o => {
        var currentObject = o;
        var originalObject = db.GetTable(o.GetType()).GetOriginalEntityState(o);
        var changedProperties = db.GetTable(o.GetType()).GetModifiedMembers(o);
    });
