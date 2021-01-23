    // <Name>Interfaces registered but potentially not used</Name>
    warnif count > 0 
    from t in JustMyCode.Types
    from i in JustMyCode.Types
    where t.DeriveFrom("StructureMap.Configuration.DSL.Registry")
       && i.IsInterface
       && t.IsUsing(i)
       && i.NbTypesUsingMe < 3 // one using for implementation, one in registry
    select i
