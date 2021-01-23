    public abstract class BaseModel : INotifyPropertyChanged
    {
    	protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
    
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    	protected virtual void OnPropertyChanged(string propertyName)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
