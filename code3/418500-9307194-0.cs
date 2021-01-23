    public class SomeClass
    {
    	private List<string> _names;
    	public object _namesLock = new object();
    	public IEnumerable<string> Names
    	{
    		get
    		{
    			if (_names == null)
    			{
    				lock (_namesLock )
    				{
    					if (_names == null)
    						_names = GetNames();
    				}
    			}
    			
    			return _names;
    		}
    	}
    	
    	private void GetNames()
    	{
    		SQLEngine sql = new SQLEngine(ConnectionString);
    		_names = sql.GetDataTable("SELECT * FROM Names").ToList<string>();
    	}	
    }
