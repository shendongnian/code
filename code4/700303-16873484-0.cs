    void Main()
    {
    	List<Customer> Customers= new List<Customer> { new Customer { Name = "John Smith" } };
    	string name = GetName(Customers); // name == "John Smith"
    }
    string GetName(object customerList)
    {
    	var custList = (IList)customerList;
    	var customer = custList[0];
    	var nameProperty = customer.GetType().GetProperty("Name");
    	return (string)nameProperty.GetValue(customer);
    }
