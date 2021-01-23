    public class Element<T>
    {
    	public Element<T> Prev { get; set; }
    	public Element<T> Next { get; set; }
    	public T Value { get; set; }
    
    	public Element(T value, Element<T> prev, Element<T> next)
    	{
            Prev = prev;
    		Next = next;
    		Value = value;
    	}
    }
