    var ParentRecord = new ParentTable () {
    SomeProperty = "Some Value",
    AnotherProperty = "Another Property Value"
    };
    
    ParentRecord.ChildTable.Add(new ChildTable () {
    ChildTableProperty = "Some Value",
    ChildTableAnotherProperty = "Some Another Value"
    });
    db.ParentTable.Add(ParentRecord);
    db.SaveChanges();
