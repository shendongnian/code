    PropertyDescriptorCollection propertiesCol = TypeDescriptor.GetProperties(objectBE);
    PropertyDescriptor property;
    for (int i = 0; i < propertiesCol.Count; i++)
    {
        property = TypeDescriptor.GetProperties(objectBE)[i];
        /*
        // Access the Property Name, Display Name and Description as follows
        property.Name          // Returns "FirstName"
        property.DisplayName   // Returns "First Name"
        property.Description   // Returns "First Name of the Member"
        */
    }
