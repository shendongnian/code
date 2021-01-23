	public interface IStorage
	{
    	T GetElement<T>(string id) where T : class;
    	void SetElement<T>(string id, T element) where T : class;
	}
	
	public class StorageImpl : IStorage
	{
		private Hashtable _hashTable = new Hashtable();
		
		public T GetElement<T>(string id) where T : class
		{
			var hashObject = _hashTable[id];
			if (hashObject.GetType() == typeof(T))
			{
				return (T)hashObject;
			}
			else
			{
				throw new Exception(
					String.Format("Item ID: {0} was of type {1}. Expecting type {2}",
						id, hashObject.GetType(), typeof(T)));
			}	
		}
		
		public void SetElement<T>(string id, T element) where T : class
		{
			lock (_hashTable.SyncRoot)
			{
				_hashTable[id] = element;
			}
		}
	}
	
	public static void RunSnippet()
	{
		IStorage storage = new StorageImpl();
		
		storage.SetElement<string>("something", "string object");
		storage.SetElement<Exception>("someexception", new Exception("some exception message"));
		
		Console.WriteLine(storage.GetElement<string>("something"));
		Console.WriteLine(storage.GetElement<Exception>("someexception").Message);
		// Throws exception
		Console.WriteLine(storage.GetElement<string>("someexception"));
	}
