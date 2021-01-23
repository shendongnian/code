    public interface IItemChange<out T> where T : MyBase
    {
    	DateTime When { get; set; }
    	string Who { get; set; }
    	T NewState { get; }
    	T OldState { get; }
    }
    
    public class ItemChange<T> : IItemChange<T> where T : MyBase
    {
    	public DateTime When { get; set; }
    	public string Who { get; set; }
    	public T NewState { get; set; }
    	public T OldState { get; set; }
    }
