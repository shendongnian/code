    //Create a dictionary of columnName => property info using the GetPropertyInfo method.
    public static IDictionary<string, PropertyInfo> propertyInfos = new Dictionary<string, PropertyInfo>
        {
            {"Name", GetPropertyInfo((Customer c) => c.Name) }
        };
    
    List<Customer> Customers= new List<Customer> { new Customer { Name = "Peter Pan" } };
    Customer customer = Customers[0];
    string column = "Name";
    PropertyInfo propertyInfo = propertyInfos[column];
    //Set property
    propertyInfo.SetValue(customer, "Captain Hook", null);
    //Get property -- Returns Captain Hook
    object propertyValue = propertyInfo.GetValue(customer, null);
