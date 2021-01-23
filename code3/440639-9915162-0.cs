    var query = context.Names;
    foreach(var pair in Properties)
    {
        query = query.Where(n => n.NameProperties.Any(np => 
            np.PropType == pair.PropType && np.PropValue == pair.PropValue;
    }
