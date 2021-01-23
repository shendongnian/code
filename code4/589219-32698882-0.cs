    Application Layer:
    
    //this Factory resides in the Domain Layer and cannot reference anything else outside it
    Person person = PersonAggregateFactory.CreateDeepAndLargeAggregate(
    			string name, string code, string streetName,...
    			and lots of other parameters...);
    
    //these ones reside in Application Layer, thus can be much more simple and readable:
    Person person = PersonAggregateFactory.CreateDeepAndLargeAggregate(CreatePersonCommand);
    Person person = PersonAggregateFactory.CreateDeepAndLargeAggregate(PersonDTO);
    
    
    
    Domain Layer:
    
    public class Person : Entity<Person>
    {
    	public Address Address {get;private set;}
    	public Account Account {get;private set;}
    	public Contact Contact {get;private set;}
    	public string Name {get;private set;}
    	
    	public Person(string name, Address address,Account account, Contact contact)
    	{
    		//some validations & assigning values...
    		this.Address = address;
    		//and so on...
    
    	}
    
    }
    
    public class Address:Entity<Address>{
    	public string Code {get;private set;}
    	public string StreetName {get;private set;}
    	public int Number {get;private set;}
    	public string Complement {get;private set;}
    	public Address(string code, string streetName, int number, string complement?)
    	{
    		//some validations & assigning values...
    		code = code;
    	}
    
    }
    
    public class Account:Entity<Account>{
    	public int Number {get;private set;}
    	
    	public Account(int number)
    	{
    		//some validations & assigning values...
    		this.Number = number;
    	}
    
    }
    
    //yout get the idea:
    //public class Contact...
