	public class TypeExtension : IMarkupExtension<Type>
	{
		public string TypeName { get; set; }
		public TypeExtension() { }
		public TypeExtension(string typeName)
			: this()
		{
			if (typeName == null) throw new ArgumentNullException("typeName");
			TypeName = typeName;
		}
		public Type ProvideValue(IServiceProvider serviceProvider)
		{
			var typeResolver = (IXamlTypeResolver)serviceProvider.GetService(typeof(IXamlTypeResolver));
			var type = typeResolver.Resolve(TypeName);
			return type;
		}
	}
