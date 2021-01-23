    internal class StaffViewModel : INotifyPropertyChanged
    {
    	private string _firstName;
    	public string FirstName
    	{
    		get { return _firstName; }
    		set
    		{
    			_firstName = value;
    			OnPropertyChanged("FirstName");
    		}
    	}
    
    	private string _lastName;
    	public string LastName
    	{
    		get { return _lastName; }
    		set
    		{
    			_lastName = value;
    			OnPropertyChanged("LastName");
    		}
    	}
    	public override string ToString()
    	{
    		return string.Format("{0} {1}", FirstName, LastName);
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public void OnPropertyChanged(string propertyName)
    	{
    		var handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
