    PropertyDescriptorCollection propertiesCol = TypeDescriptor.GetProperties(objectBE);
    PropertyDescriptor property;
    for (int i = 0; i < propertiesCol.Count; i++)
    {
        property = TypeDescriptor.GetProperties(objectBE)[i];
        /*
        // Access the Property Name, Display Name and Description as follows
        property.Name
        property.DisplayName
        property.Description
        */
    }
