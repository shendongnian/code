	public T Map<T>(XElement element) where T : class, new()
	{
		T entity = (T)Activator.CreateInstance(typeof(T));
		if (element.HasAttributes)
		{
			MapXMLAttributesToObject<T>(element, entity);
		}
		if (element.HasElements)
		{
			foreach (var childElement in element.Elements())
			{
				var property = GetProperty<T>(childElement.Name.LocalName);
				// If the child element has child elements as well, we know this is a collection.
				if (childElement.HasElements)
				{
					// Assume collections are of type IEnumerable<T> or List<T>
					var collectionElementType = property.PropertyType.GetGenericArguments()[0];
					// var collectionValue = new List<collectionElementType>()
					var collectionValue = Activator.CreateInstance(typeof(List<>).MakeGenericType(collectionElementType));
					foreach (var grandchildElement in childElement.Elements())
					{
						// var collectionElement = this.Map<collectionElementType>(grandchildElement);
						var collectionElement = this.GetType().GetMethod("Map").MakeGenericMethod(collectionElementType).Invoke(this, new object[] { grandchildElement });
						collectionValue.GetType().GetMethod("Add").Invoke(collectionValue, new object[] { collectionElement });
					}
					property.SetValue(entity, collectionValue, null);
				}
				else
				{
					// I'm not sure what this should do -- this case doesn't happen in your example.
					throw new NotImplementedException();
				}
			}
		}
		return entity;
	}
