    warnif count > 0 
    let registryDerived = JustMyCode.Types.Where(t => t.DeriveFrom("StructureMap.Configuration.DSL.Registry"))
    from i in JustMyCode.Types.UsedByAny(registryDerived)
    where i.IsInterface &&
          i.NbTypesUsingMe < 3 // one using for implementation, one in registry
    select new { i, 
                 registryDerivedUser = i.TypesUsingMe.Intersect(registryDerived),
                 i.TypesUsingMe }
