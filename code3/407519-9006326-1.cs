	public class Factory
	{
		private static int _id = 0;
		
		// Use Dictionary to store the mapping from int to Type
		// instead of ActionScript "classLib = new Array();"
		private static readonly IDictionary<int, Type> _typeMappings = new Dictionary<int, Type>();
		
		public Factory()
		{
		}
		
		public static int AddClassLink(Type type)
		{
			// To insure uniqueness, increment a static local id and use that
			int localId = ++_id;
			
			// Store the Type of the class to instantiate against the integer ID
			// Similar to ActionScript "classLib.push(logicClass); "
			_typeMappings[localId] = type;			// Set in dictionary
			return localId;
		}
		
		pubilc static FactoryObject CreateClassFromId(int id, DataObject constructorDataObject)
		{
			// Get the class type by integer Id. 
			// You can also use _typeMappings.Contains and _typeMappings.TryGetValue() to 
			// add some checking first
			var type = _typeMappings[id];
			
			// This is equivalent to new DerivedFactoryObject() where Type
			// is the runtime Type of the class registered in AddClassLink
			var obj = (FactoryObject)Activator.CreateInstance(type);
			
			// Initialise and return 
			obj.Init(constructorDataObject);
			return obj;
		}
	}
