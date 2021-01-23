	public override DynamicMetaObject BindConvert(ConvertBinder binder)
	{
		BindingRestrictions restrictions 
			= BindingRestrictions.GetTypeRestriction(Expression, LimitType);
		//if the type requested is compatible with the 
		//instance, there's no conversion to be done.
		if (binder.Type.IsAssignableFrom(LimitType))
			return binder.FallbackConvert(
				new DynamicMetaObject(Expression, restrictions, Value));
		if (LimitType.IsGenericType && 
			LimitType.GetGenericTypeDefinition().Equals(typeof(DynamicProxy<>)))
		{
			//get the type parameter for T
			Type proxiedType = LimitType.GetGenericArguments()[0];
			//now check that the proxied type is compatible 
			//with the desired conversion type
			if(binder.ReturnType.IsAssignableFrom(proxiedType))
			{
				//this FieldInfo lookup can be cached by 
				//proxiedType in a static ConcurrentDictionary
				//to cache the reflection for future use
				FieldInfo tField = LimitType.GetField("t", 
					BindingFlags.Instance | BindingFlags.NonPublic);
				//return a field expression that retrieves the 
				//private 't' field of the DynamicProxy
				//note that we also have to convert 'Expression'
				//to the proxy type - which we've already ascertained
				//is the LimitType for this dynamic operation.
				var fieldExpr = Expression.Field(
					Expression.Convert(Expression, LimitType), tField);
				//but because we're allowing bases or interfaces of 'T',
				//it's a good idea to chuck in a 'Convert'
				return new DynamicMetaObject(
					Expression.Convert(fieldExpr, binder.ReturnType),
					restrictions);
			}
		}
		return base.BindConvert(binder);
	}
