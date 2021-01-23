        public void SetDocumentProperty(string propertyName, object value)
        {
            // Get all the custom properties
            object customProperties = wordDocument.CustomDocumentProperties;
            Type customPropertiesType = customProperties.GetType();
            // Retrieve the specific custom property item
            object customPropertyItem = customPropertiesType.InvokeMember("Item",
                BindingFlags.Default | BindingFlags.GetProperty, null, customProperties,
                new object[] { propertyName });
            Type propertyNameType = customPropertyItem.GetType();
            // Set the value of the specific custom property item
            propertyNameType.InvokeMember("Value", BindingFlags.Default | BindingFlags.SetProperty, null,
                customPropertyItem, new object[] { value });
        }
