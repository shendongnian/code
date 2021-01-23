    ...
    HasMany(x => x.Managers)
       .Cascade.AllDeleteOrphan()
       .Fetch.Select()
       .Inverse().KeyColumn(MappingColumn)
       .Where("Type = 1") // the Column name in the Person table
    ;                     // and the value 1 as the enum of the Manager
    ...
    // The same for the others
