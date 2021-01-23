    public static class Ext
    {
    	public static IObservable<IList<T>> BufferUntil<T>(
             this IObservable<T> source, 
             Func<T, bool> predicate)
    	{
    		var singleSource = source.Publish().RefCount();
    		var trigger = singleSource.Where(predicate);
    		return singleSource.Buffer(trigger);
    	}
    	
    	public static IObservable<string> Split(
           this IObservable<char> incomingCharacters, 
           char sep)
    	{
    		return incomingCharacters
                 .BufferUntil(c => c == sep)
                 .Select(carr => new string(carr.ToArray()));
    	}
    }
