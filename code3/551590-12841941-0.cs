    public class PersonViewModelPrefixed
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; } 
    }
	
	public static void Main(string[] args)
	{	
            Person defaultPerson = getDefaultPerson();
            PersonViewModelPrefixed defaultPrefixedVm = getDefaultPrefixedViewModel();
            //flatten - Entity to View Model
            PersonViewModelPrefixed pvm = Flatten(defaultPerson);
            //unflatten - View Model to Entity
            Person person2 = Unflatten(defaultPrefixedVm);	
		Console.ReadLine();
	}		
	
	//unflatten - View Model to Entity
	private static Person Unflatten(PersonViewModelPrefixed personViewModel)
	{
		Person p = new Person();
		p.InjectFrom<UnflatLoopValueInjection>(personViewModel);
		return p;
	}
	//flatten - Entity to View Model
	private static PersonViewModelPrefixed Flatten(Person person)
	{
		PersonViewModelPrefixed pvm = new PersonViewModelPrefixed();
		pvm.InjectFrom<FlatLoopValueInjection>(person);
		return pvm;
	}
