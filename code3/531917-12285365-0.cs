	public class CustomBinder : SerializationBinder
	{
		static string assemblyToUse = typeof (MyObject).Assembly.FullName;
		public override Type BindToType(string assemblyName, string typeName)
		{
			if (typeName.EndsWith("MyType"))
			    return typeof(MyTypeInThisAssembly);
			return base.BindToType(assemblyName, typeName);
		}
	}
	var formatter = new BinaryFormatter{Binder = new CustomBinder()};
	var obj = formatter.Deserialize(...)
