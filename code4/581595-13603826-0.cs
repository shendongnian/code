    class DataHolder : INotifyPropertyChanged
    {
    	public bool MyValue
    	{
    		get{return mMyValue;}
    		set{mMyValue = value; RaiseProperty("MyValue");}
    	}
    	
    	private bool mMyValue;
    }
