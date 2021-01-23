	public class TypeChain
	{
		private List<Type> types;
		
		public TypeChain(Type t)
		{
			types = new List<Type>();
			types.Add(t);
		}
			
		// searching for common base class (either concrete or abstract)
		public TypeChain FindBaseClassWith(Type typeRight)
		{
			this.types.Add(typeRight);
			return this;
		}
		
		public Type Resolve()
		{
			// do something to analyze all of the types
			if (types.All (t => t == null))
				return null;
			else
				types = types.Where (t => t != null).ToList();
			
			var temp = types.First();
			foreach (var type in types.Skip(1))
			{
				temp = temp.FindBaseClassWithHelper(type);
			}
			return temp;
		}
	}
