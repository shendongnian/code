    public class School
    {
    	private List<Manageable> manageables;
    	public void Accept(IManageableVisitor visitor)
    	{
    		foreach(var m in this.manageables)
    		{
    			m.Visit(visitor);
    		}
    	}
    }
