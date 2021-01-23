    var allButExtensionData = propInfos.Where(p => p.Name != "ExtensionData"
              || typeof(DataMemberAttribute).IsAssignableFrom(p.PropertyType));
    foreach (var prop in allButExtensionData)
    {
       // ...
    }
