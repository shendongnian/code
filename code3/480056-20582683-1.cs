	public class GenericArgumentBindingGenerator : IBindingGenerator
	{
		private readonly Type m_Generic;
		public GenericArgumentBindingGenerator(Type generic)
		{
			if (!generic.IsGenericTypeDefinition)
			{
				throw new ArgumentException("given type must be a generic type definition.", "generic");
			}
			m_Generic = generic;
		}
		public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
		{
			if (type == null)
				throw new ArgumentNullException("type");
			if (bindingRoot == null)
				throw new ArgumentNullException("bindingRoot");
			if (type.IsAbstract || type.IsInterface)
			{
				return Enumerable.Empty<IBindingWhenInNamedWithOrOnSyntax<object>>();
			}
			var bindings = new List<IBindingWhenInNamedWithOrOnSyntax<object>>();
			IBindingWhenInNamedWithOrOnSyntax<object> binding = bindingRoot
				.Bind(typeof(IExtract)) // you maybe want to pass typeof(IExtract) to constructor
				.To(m_Generic.MakeGenericType(type));
			bindings.Add(binding);
			return bindings;
		}
	}
