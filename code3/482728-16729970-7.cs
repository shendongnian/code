    public partial class User : BaseModel
    {
    	private int _id;
    	public int Id 
    	{ 
    		get { return _id; } 
    		set
    		{
    			if (value != _id) {
    				_id = value;
    				 OnPropertyChanged("Id");
    			}
    		} 
    	}
    
    	private string _name;
    	public string Name 
    	{ 
    		get { return _name; } 
    		set
    		{
    			if (value != _name) {
    				_name = value;
    				 OnPropertyChanged("Name");
    			}
    		} 
    	}
