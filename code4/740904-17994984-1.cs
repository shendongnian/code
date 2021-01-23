    [ServiceKnownType("GetKnownTypes", typeof(Helper))]
    public interface MyService
    {
        ...
    }
	static class Helper
	{
		public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
		{
			List<Type> knownTypes = new List<System.Type>();
			// Add any types to include here.			
			string[] types = File.ReadAllLines(@"..\..\..\types.txt");
			foreach (string type in types)
			{
				knownTypes.Add(Type.GetType(type));
			}
			
			return knownTypes;
		}
	}
