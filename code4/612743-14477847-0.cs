	get
	{
		if (myObject == null)
			return new MyObject(null);
		object returnValue = null;
		bool foundReturnValue = false;
		object[] indexArgs = { key };
		Type myObjectType = myObject.GetType();
		if (typeof(IList).IsAssignableFrom(myObjectType))
		{
			try
			{
				returnValue = ((IList)myObject)[((int)key)];
				foundReturnValue = true;
			}
			catch (Exception) { }
		}
		if (!foundReturnValue)
		{
			foreach (PropertyInfo property in myObjectType.GetProperties())
			{
				ParameterInfo[] indexParameters = property.GetIndexParameters();
				foreach (ParameterInfo indexParameter in indexParameters)
				{
					if (indexParameter.ParameterType.IsAssignableFrom(key.GetType()))
					{
						try
						{
							returnValue = property.GetValue(myObject, indexArgs);
							foundReturnValue = true;
						}
						catch (Exception) { }
					}
					if (foundReturnValue == true)
						break;
				}
				if (foundReturnValue == true)
					break;
			}
		}
		return new MyObject(returnValue);
	}
