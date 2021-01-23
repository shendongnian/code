    // add to config
    var typemap = new TypeMap();
    typemap.Id(x => x.Section, "ENTITY_SECTION");
    typemap.Where("ENTITY_TYPE = 123");
    typemap.EntityName("Type for EntityX");
    References(x => x.Type)
       .Column("ENTITY_SECTION")
       .EntityName("Type for EntityX");
