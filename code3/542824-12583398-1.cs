    public class SubObject : BaseObject
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    
    	public bool IsEqualTo(SubObject other)
    	{
    		var compExpr = this.CreatePropertiesEqualExpression(other);
    		var compFunc = compExpr.Compile();
    		return compFunc(other);
    	}
    }
