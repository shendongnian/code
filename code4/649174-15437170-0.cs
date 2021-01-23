    class MainViewModel : INotifyPropertyChanged
    {
    	private DateTime _myDate;
    
    	public DateTime MyDate
    	{
    		get { return _myDate; }
    		set 
    		{ 
    			_myDate = value; 
    			OnPropertyChanged("MyDate"); 
    			// only for testing...
    			Console.WriteLine("value: " + value);
    		}
    	}
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    	public void OnPropertyChanged(string name)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null)
    		{
    			handler(this, new PropertyChangedEventArgs(name));
    		}
    	}
    }
