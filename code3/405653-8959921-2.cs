	public class MammalFactory
	{
		private readonly IEnumerable<Type> _mammalTypes;
		public MammalFactory()
		{
			var currentAssembly = Assembly.GetExecutingAssembly();
			_mammalTypes = currentAssembly.GetTypes()
				.Where(t => typeof(Mammal).IsAssignableFrom(t) && !t.IsAbstract);
		}
		public Mammal Create(MammalTypes mammalType)
		{
			return _mammalTypes
				.Select(type => CreateSpecific(type, mammalType))
				.First(mammal => mammal != null);
		}
		public Mammal CreateSpecific(Type type, MammalTypes mammalEnumType)
		{
			var mammalInstance = (Mammal)Activator.CreateInstance(type);
			return mammalInstance.Is(mammalEnumType) ? mammalInstance : null;
		}
	}
