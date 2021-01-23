	Insert(new PersonDTO());
	Insert(new OrderDTO());
	Insert(new PersonDTO());
	
	List<PersonDTO> persons = Get<PersonDTO>();
	List<OrderDTO> orders = Get<OrderDTO>();
	
	Console.WriteLine(persons.Count); //2
	Console.WriteLine(orders.Count); //1
