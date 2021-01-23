    public interface IDatedEntity
    {
    	DateTime CreationDate { get; set; }
    	DateTime UpdateDate { get; set; }
    }
    
    public partial class User : IDatedEntity
    {
    	public DateTime CreationDate { get; set; }
    	public DateTime UpdateDate { get; set; }
    	...
    }
    ...
    public partial class Customer : IDatedEntity
    {
    	public DateTime CreationDate { get; set; }
    	public DateTime UpdateDate { get; set; }
    	...
    }
