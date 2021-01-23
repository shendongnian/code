    var distanceAttribute = new UnitTypeAttribute(UnitType.Distance);
    foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(dbObject))
    {
        if (property.Attributes.Matches(distanceAttribute))
        {
            // Here's a property that is a distance.
        }
    }
