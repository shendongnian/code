    public abstract class Manageable
    {
    	abstract void Accept(IManagebleVisitor visitor);
    }
    
    public interface IManageableVisitor
    {
    	void Visit(Department d);
    	void Visit(Building b);
    }
    
    public class Department : Manageable { ... }
    public class Building : Manageable { ... }
