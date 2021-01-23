		private static IEnumerable<Type> GetKnownTypes() {
			Type baseType = typeof(MyBaseType);
			return AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(x => x.DefinedTypes)
				.Where(x => x.IsClass && !x.IsAbstract && x.GetCustomAttribute<DataContractAttribute>() != null && baseType.IsAssignableFrom(x));
		}
