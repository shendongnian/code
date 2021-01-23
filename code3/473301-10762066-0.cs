    public interface IFilter<T> where T : Control
    {
    	T Control { get; set; }
    	T ControlMethod();
    }
