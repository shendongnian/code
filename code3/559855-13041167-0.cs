    public class User
    {
    	public User(string firstName, string lastName)
    	{
    		FirstName = firstName;
    		LastName = lastName;
    	}
    
    	private string _firstName;
    	public string FirstName
    	{
    		get { return _firstName; }
    		set
    		{
    			if (!IsValid(value))
    				// throw / handle appropriately
    			else
    				_firstName = value;
    		}
    	}
    }
