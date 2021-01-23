    public interface IParameterizable
    {
    	IEnumerable<SqlParameter> GetParameters();
    }
    
    public SqlParameterAttribute : Attribute
    {
    	public string Name { get; set; }
    }
    
    public class InsertTradingAcctTransFrontParameters : IParameterizable
    {
    	[SqlParameter( Name = "@mBatchName" )]
    	public int CollectionId { get; set; }
    	
    	/* ... */
    	
    	IEnumerable<SqlParameter> GetParameters()
    	{
    		// Validation for properties, etc...
    		if(0 > CollectionId) throw new MeaningfulException("CollectionId must be greater than 0");
    		
    		yield return new SqlParameter(GetParameterName("CollectionId"), CollectionId);
    	}
    	
    	private string GetParameterName(string propertyName)
    	{
    		var attribute = GetType().GetProperty(propertyName).GetCustomAttributes(typeof(SqlParameterAttribute), false).SingleOrDefault();
    		
    		if(attribute == null) throw new NotImplementedException(string.Format("SqlParameter is not defined for {0}", propertyName);
    		
    		return ((SqlParameterAttribute)attribute).Name;
    	}
    }
