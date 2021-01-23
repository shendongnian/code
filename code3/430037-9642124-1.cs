    public class MainViewModel : ValidationViewModel
    {
    	public MainViewModel()
    	{
    		this.Validator.AddValidationFor(() => this.SomeProperty).NotEmpty().Show("Enter a value");
    	}
    
    	private string someProperty;
    
    	public string SomeProperty
    	{
    		get { return someProperty; }
    		set
    		{
    			someProperty = value;
    			RaisePropertyChanged("SomeProperty");
    		}
    	}
    }
