    public class StudentViewModel : PropertyChangedBase
    {
    	private string firstName;
    	public string FirstName
    	{
    		get { return firstName; }
    		set
    		{
    			firstName = value;
    			NotifyOfPropertyChange(() => FirstName);
    		}		
    	}
    	
    	private string lastName
    	public string LastName
    	{
    		get { return lastName; }
    		set
    		{
    			lastName = value;
    			NotifyOfPropertyChange(() => LastName);
    		}		
    	}
    }
