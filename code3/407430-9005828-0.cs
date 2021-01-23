    warnif count > 0 
    
    // Namespaces with suffix Interface
    let interfacesNamespaces = 
       Application.Namespaces.WithNameLike("Interface$").ToHashSet()
    
    // Match namespaces that are using something else than interfacesNamespaces 
    from n in Application.Namespaces
    let nonInterfacesNamespacesUsed = n.NamespacesUsed.Except(interfacesNamespaces)
    where nonInterfacesNamespacesUsed.Count() > 0
    select new { n, nonInterfacesNamespacesUsed }
