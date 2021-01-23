    // IDictionary<string, bool>
    HasMany(x => x.Dictionary1).AsMap<string>("keyColumn").Element("Enabled");
    // IDictionary<SomeEnum, bool>  (Enum will be mapped as int)
    HasMany(x => x.Dictionary2).AsMap("SomeEnum").Element("Enabled");  
    // IDictionary<Entity, string>
    HasMany(x => x.Dictionary3).AsEntityMap().Element("valueColumn"); 
 
