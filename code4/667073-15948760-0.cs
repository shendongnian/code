	public void SetUpConvension(ModelMapper mapper)
	{
		mapper.BeforeMapProperty += MapperOnBeforeMapProperty;
	}
	private void MapperOnBeforeMapProperty(
		IModelInspector modelInspector,
		PropertyPath member,
		IPropertyMapper propertyCustomizer)
	{
		Type propertyType;
		// requires some more condition to check if it is a property mapping or field mapping
		propertyType = (PropertyInfo)member.LocalMember.PropertyType;
		if (!propertyType == typeof(decimal)) 
		{
			propertyCustomizer.Precision(9);
			propertyCustomizer.Scale(6);
		}
	}
