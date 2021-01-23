    //auto-generated (or half implemented) code
    public partial User
    {
    	public partial void OnFirstNameChanged();
    
    	private string _FirstName = "";
    	public string FirstName
    	{
    		get
    		{
    			return _FirstName;
    		}
    		set
    		{
    			_FirstName = value;
    			OnFirstNameChanged();
    		}
    	}
    }
    
    //MyCustomStuff.cs
    public partial User
    {
    	public partial void OnFirstNameChanged()
    	{
    		Console.Write(string.Format("Your name is {0}", FirstName));
    	}
    }
