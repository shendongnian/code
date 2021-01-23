    var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
    var blockProperties = typeof(FixedLengthBlock).GetProperties(bindingFlags);
    var newObj = Activator.CreateInstance(typeof(FixedLengthBlock))
    foreach (var property in blockProperties)
    {
        if (block.Properties.ContainsKey(property.Name))
        {
            var propertyInfo = newObj.GetType().GetProperty(property.Name, bindingFlags);
            if (propertyInfo == null) { continue; }
            propertyInfo.SetValue(newObj, block.Properties[property.Name]);
        }
    }
