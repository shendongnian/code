    var properties = relationshipDetails.GetType().GetProperties();
    
    foreach (string c in _cols)
    {
        var currentProperty = properties.Single( p=> p.Name == c );
        if (currentProperty.GetValue(relationshipDetails, null) != null)
        {
            setValue(currentProperty.GetValue(relationshipDetails, null).ToString(), c);
        }
    }
