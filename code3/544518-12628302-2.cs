    public class CustomerListList : List<CustomerList> { }	
	public class CustomerList : List<Customer> { }
	public class Customer
	{
       public int ID { get; set; }
       public string SomethingWithText { get; set; }
    }
