    public class Pair<P, T>
    {
    	public Pair() { }
    	public Pair(P first, T second)
    	{
    		First = first;
    		Second = second;
    	}
    	public P First { get; set; }
    	public T Second { get; set; }
    }
