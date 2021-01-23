    // IDictionary<string, bool>
    HasMany(x => x.Dictionary1).AsMap<string>("keyColumn").Element("Enabled");
    // IDictionary<SomeEnum, bool>
    HasMany(x => x.Dictionary2).AsMap<string>("SomeEnum").Element("Enabled"); 
    // IDictionary<Entity, string>
    HasMany(x => x.Dictionary3).AsEntityMap().Element("valueColumn"); 
 
