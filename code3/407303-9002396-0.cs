    var elementType = (
        from iface in myList.GetType().GetInterfaces()
        where iface.IsGenericType
        where iface.GetGenericTypeDefinition() == typeof(IList<>)
        select iface.GetGenericArguments()[0])
            .Single();
