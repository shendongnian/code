    public interface IFoo1
    {
    	float Progress { get; set; }
    	bool IsDone { get; set; }
    }
    
    public interface IFoo2
    {
    	bool Canceled { get; set; }
    }
    
    public abstract class ObjectA : IFoo1
    {
    	public float Progress { get; set; }
    	public bool IsDone { get; set; }
    }
    
    public abstract class ObjectB : IFoo2
    {
    	public bool Canceled { get; set; }
    }
    
    public class ObjectC : IFoo1, IFoo2
    {
    	public float Progress { get; set; }
    	public bool IsDone { get; set; }
    	public bool Canceled { get; set; }
    }
