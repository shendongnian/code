    void SetWordDocumentPropertyValue(Word.Document document, string propertyName, string propertyValue)
    {
      object builtInProperties = document.BuiltInDocumentProperties;
      Type builtInPropertiesType = builtInProperties.GetType();
      object property = builtInPropertiesType.InvokeMember("Item", System.Reflection.BindingFlags.GetProperty, null, builtInProperties, new object[] { propertyName });
      Type propertyType = property.GetType();
      propertyType.InvokeMember("Value", BindingFlags.SetProperty, null, property, new object[] { propertyValue });
      document.UpdateSummaryProperties();
      document.Save();
    }
