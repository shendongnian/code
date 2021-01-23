    class Student : INotifyPropertyChanged
    {
    	...
    	
    	private string studentLastName;
    	
    	public string StudentLastName
    	{
    		get
    		{
    			return this.studentLastName;
    		}
    		
    		set
    		{
    			if(this.studentLastname != value)
    			{
    				this.studentLastName = value;
    				this.OnPropertyChanged("StudentLastName");
    			}
    		}
    	}
    }
