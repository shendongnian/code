    public interface IMoop<T>
    {
    	T Moop();
    }
    
    public class MoopImplementor : IMoop<string>
    {
    	public string Moop() { return ""; }
    }
