    public class PersonFilter : CollectionFilterBase<Person>
    {
    	private string name;
        public string Name
        {
            get
            {
    			return name;
    		}
    		
    		set
    		{
    			name = value;
    			//NotifyPropertyChanged somehow, I'm using Caliburn.Micro most of the times, so:
    			NotifyOfPropertyChange(() => Name);
    			AddFilter("Name", Name);			
    		}
    	}
    	private int age;
    	public int Age
    	{
    		get
    		{
    			return age;
    		}
    		set
    		{
    			age = value;
    			//Same as above, notify
    			AddFilter("Age", Age.ToString()) // only a string filter...
    		}
    	}
    }
