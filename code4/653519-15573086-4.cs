	private static void EnumerateAllIncludesList(DbContext context, IEnumerable entities, List<object> entitiesLoaded = null)
	{
		if (entitiesLoaded == null)
			entitiesLoaded = new List<object>();
		foreach (var entity in entities)
			EnumerateAllIncludesEntity(context, entity, entitiesLoaded);
	}
	private static void EnumerateAllIncludesEntity(DbContext context, object entity, List<object> entitiesLoaded)
	{
		if (entitiesLoaded.Contains(entity))
			return;
		entitiesLoaded.Add(entity);
		Type type = entity.GetType();
		var properties = type.GetProperties();
		foreach (var propertyInfo in properties)
		{
			var propertyType = propertyInfo.PropertyType;
			bool isCollection = propertyType.GetInterfaces().Any(x => x == typeof(IEnumerable)) &&
								!propertyType.Equals(typeof(string));
			if (isCollection)
			{
				var entry = context.Entry(entity);
				if(entry.Member(propertyInfo.Name) as DbCollectionEntry == null)
					continue;
				entry.Collection(propertyInfo.Name).Load();
				var propertyValue = propertyInfo.GetValue(entity);
				if (propertyValue == null)
					continue;
				EnumerateAllIncludesList(context, (IEnumerable)propertyValue, entitiesLoaded);
			}
			else if ((!propertyType.IsValueType && !propertyType.Equals(typeof(string))))
			{
				var entry = context.Entry(entity);
				if (entry.Member(propertyInfo.Name) as DbReferenceEntry == null)
					continue;
				entry.Reference(propertyInfo.Name).Load();
				var propertyValue = propertyInfo.GetValue(entity);
				if (propertyValue == null)
					continue;
				EnumerateAllIncludesEntity(context, propertyValue, entitiesLoaded);
			}
			else
				continue;
		}
	}
