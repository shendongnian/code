    public class ParamsWrapper<T> : IEnumerable<T>
    {
    	private readonly IEnumerable<T> seq;
    
    	public ParamsWrapper(IEnumerable<T> seq)
    	{
    		this.seq = seq;
    	}
    
    	public static implicit operator ParamsWrapper<T>(T instance)
    	{
    		return new ParamsWrapper<T>(new[] { instance });
    	}
    
    	public static implicit operator ParamsWrapper<T>(List<T> seq)
    	{
    		return new ParamsWrapper<T>(seq);
    	}
    
    	public IEnumerator<T> GetEnumerator()
    	{
    		return this.seq.GetEnumerator();
    	}
    
    	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    	{
    		return this.GetEnumerator();
    	}
    }
