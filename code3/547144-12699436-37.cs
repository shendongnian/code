    public class PersonHook : HookObj<Person>
    {
    	protected override Person Parse(string value)
    	{
    		string[] parts = value.Split(',');
    		var person = new Person(parts[0], parts[1]);
    		
    		if (person.FirstName == "Bob")
    			throw new Exception("You have a silly name and I don't like you.");
    			
    		if (String.IsNullOrWhiteSpace(person.FirstName))
    			throw new Exception("No first name provided.");
    			
    		if (String.IsNullOrWhiteSpace(person.LastName))
    			throw new Exception("No last name provided.");
    		
    		return person;
    	}
    }
