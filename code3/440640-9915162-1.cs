    // c is a searchCriteria object.
    var query = context.Names
        .Where(n => n.FirstName == c.FirstName && n.LastName == c.LastName);
    foreach(var pair in c.Properties)
    {
        query = query.Where(n => n.NameProperties.Any(np => 
            np.PropType == pair.PropType && np.PropValue == pair.PropValue;
    }
