    public class Test : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private string myProperty;
    	
    	public string MyProperty
    	{
    		get
    		{
    			return this.myProperty;
    		}
    
    		set
    		{
    			if (value != this.myProperty)
    			{
    				this.myProperty = value;
    
    				if (this.PropertyChanged != null)
    				{
    					this.PropertyChanged(this, new PropertyChangedEventArgs("MyProperty"));
    				}
    			}
    		}
    	}
    }
