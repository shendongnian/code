      public override object ConvertStringToValue(string parameter, Type parameterType)
    		{
    			if (parameterType.IsEnum)
    			{
    				if (string.IsNullOrEmpty(parameter))
    				{
    					return Activator.CreateInstance(parameterType);
    				}
    			}
    
    			return base.ConvertStringToValue(parameter, parameterType);
    
    		}
