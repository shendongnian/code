    foreach (var property in this.GetType().GetProperties())
    {
        var mapToAttribute = property.GetCustomAttributes(typeof(MapToAttribute), false).SingleOrDefault() as MapToAttribute;
        if (mapToAttribute != null)
        {
            property.SetValue(this, doc.SelectSingleNode(mapToAttribute.XPathSelector).Value);
        }
    }
