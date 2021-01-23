	public class LockedCollection
	{
		private class CollectionImpl : ICollection<int>
		{
           //Collection methods
		}
		private sealed class CollectionWrapper : ICollection<int>, IDisposable
		{
           public CollectionWrapper(CollectionImpl inner)
           {
               _inner = inner;
           }
           private CollectionImpl _inner
           //Collection methods all just wrapping calls to inner
           public void Dispose()
           {
              _inner = null;
           }
		}
		private CollectionImpl _instance - new CollectionImpl();
		private object _lock = new object();
		public void DoStuff(Action<ICollection<int>> task)
		{
			lock(_lock)
			{
                using(var wrapper = new CollectionWrapper(_instance))
                {
		    		task(wrapper);
                }
			}
		}
	}
