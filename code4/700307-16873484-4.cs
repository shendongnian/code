    void Main()
    {
        List<Customer> Customers= new List<Customer> { new Customer { Name = "John Smith" } };
        string name = (string)GetProp(Customers, 0, "Name"); // name == "John Smith"
    }
    object GetProp(object customerList, int index, string propertyName)
    {
        var custList = (IList)customerList;
        var customer = custList[index];
        var nameProperty = customer.GetType().GetProperty(propertyName);
        return nameProperty.GetValue(customer);
    }
