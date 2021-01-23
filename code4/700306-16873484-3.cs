    void Main()
    {
    	List<Customer> Customers= new List<Customer> { new Customer { Name = "John Smith" } };
    	GetProp(Customers[0], "Name"); // "John Smith"
    	SetProp(Customers[0], "Name", "Joe");
    	GetProp(Customers[0], "Name"); // "Joe"
    }
    object GetProp(Customer customer, string propertyName)
    {
    	var property = typeof(Customer).GetProperty(propertyName);
    	return property.GetValue(customer);
    }
    void SetProp(Customer customer, string propertyName, object propertyValue)
    {
    	var property = typeof(Customer).GetProperty(propertyName);
    	property.SetValue(customer, propertyValue);
    }
