    public class SubObject : BaseObject
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	private Func<BaseObject, bool> eqFunc;
    
    	public bool IsEqualTo(SubObject other)
    	{
    		if(this.eqFunc == null)
    		{
    			var compExpr = this.CreatePropertiesEqualExpression(other);
    			this.eqFunc = compExpr.Compile();
    		}
    		return this.eqFunc(other);
    	}
    }
