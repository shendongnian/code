    public interface ISource
    {
    	DataTable Table { get; }
    	string Name { get; set; }
    }
    
    public class MySource : ISource
    {
    	private DataTable table;
    	public DataTable Table
    	{
    		get
    		{
    			if (table == null)
    				// Initialize your data.
    				table = new System.Data.DataTable();
    			return table;
    		}
    		private set
    		{
    			this.table = value;
    		}
    	}
    	public string Name { get; set; }
    }
