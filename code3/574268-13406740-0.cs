    foreach (AttributeValue attributeValue in attributeValues)
    {
        string label = attributes.First(a => a.ID == attributeValue.AttributeID).Name;
        string propertyName = attributeValue.AttributeName + "Label";
        PropertyInfo pi = GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        // check for null, if it is possible that property not exists
        pi.SetValue(this, label, null);
    }
