	public class Factory
	{
		private static int _id = 0;
		
		// Use Dictionary to store the mapping from int to Type
		private static readonly IDictionary<int, Type> _typeMappings = new Dictionary<int, Type>();
		
		public Factory()
		{
		}
		
		public static int AddClassLink(Type type)
		{
			int localId = localId;
			_typeMappings[localId] = type;			// Set in dictionary
			return localId;
		}
		
		pubilc static FactoryObject CreateClassFromId(int id, DataObject constructorDataObject)
		{
			var type = _typeMappings[id];
			var obj = (FactoryObject)Activator.CreateInstance(type);
			obj.Init(constructorDataObject);
			return obj;
		}
	}
