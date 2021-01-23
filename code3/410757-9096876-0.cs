    A a = new A();
    B b = new B();
    GenericConverter<A,B>.Convert(a, b);
    public static class GenericConverter<TInput, TOutput> where TOutput : new()
    {
        /// <summary>
        /// Converts <paramref name="entity"/> from <see cref="TInput"/> to <see cref="TOutput"/>
        /// </summary>
        /// <param name="entity">the object to convert</param>
        /// <returns>The object converted</returns>
    	public static TOutput Convert(TInput entity)
    	{
    		if(entity is Enum)
    			throw new NotImplementedException("Entity is an enumeration - Use ConvertNum!");
    
    		TOutput output = new TOutput();
    
    		Type fromType = entity.GetType();
    		Type toType = output.GetType();
    
    		PropertyInfo[] props = fromType.GetProperties();
    
    		foreach (PropertyInfo prop in props)
    		{
    			PropertyInfo outputProp = toType.GetProperty(prop.Name);
    
    			if (outputProp != null && outputProp.CanWrite)
    			{
    				string propertyTypeFullName = prop.PropertyType.FullName;
    
    				object value = prop.GetValue(entity, null);
    				outputProp.SetValue(output, value, null);
    			}
    		}
    
    		return output;
    	}
    }
