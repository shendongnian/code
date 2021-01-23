    public class MyModel : INotifyPropertyChanged
    {
    	private string _status;
    	public string Status
    	{
    		get { return _status; }
    		set { _status = value; OnPropertyChanged(); }
    	}
    
    	// Default INotifyPropertyChanged
    	public event PropertyChangedEventHandler PropertyChanged;
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		var handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
    
    public class MyViewModel : INotifyPropertyChanged
    {
    	public string Status
    	{
    		get { return _model.Status; }
    	}
    
    	private PropertyChangedProxy<MyModel, string> _statusPropertyChangedProxy;
    	private MyModel _model;
    	public MyViewModel(MyModel model)
    	{
    		_model = model;
    		_statusPropertyChangedProxy = new PropertyChangedProxy<MyModel, string>(
    			_model, myModel => myModel.Status, s => OnPropertyChanged("Status")
    		);
    	}
    
    	// Default INotifyPropertyChanged
    	public event PropertyChangedEventHandler PropertyChanged;
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		var handler = PropertyChanged;
    		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
