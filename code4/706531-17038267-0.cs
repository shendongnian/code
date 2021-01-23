	public class LockedCollection
	{
		private class CollectionImpl : ICollection<int>
		{
           //Collection methods
		}
		private CollectionImpl _instance - new CollectionImpl();
		private object _lock = new object();
		public void DoStuff(Action<ICollection<int>> task)
		{
			lock(_lock)
			{
				task(_instance);
			}
		}
	}
