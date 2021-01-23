    internal static object DefaultToType(IConvertible value, Type targetType, IFormatProvider provider)
    {
    	if (targetType == null)
    	{
    		throw new ArgumentNullException("targetType");
    	}
    	RuntimeType left = targetType as RuntimeType;
    	if (left != null)
    	{
    		if (value.GetType() == targetType)
    		{
    			return value;
    		}
    		if (left == Convert.ConvertTypes[3])
    		{
    			return value.ToBoolean(provider);
    		}
    		if (left == Convert.ConvertTypes[4])
    		{
    			return value.ToChar(provider);
    		}
    		if (left == Convert.ConvertTypes[5])
    		{
    			return value.ToSByte(provider);
    		}
    		if (left == Convert.ConvertTypes[6])
    		{
    			return value.ToByte(provider);
    		}
    		if (left == Convert.ConvertTypes[7])
    		{
    			return value.ToInt16(provider);
    		}
    		if (left == Convert.ConvertTypes[8])
    		{
    			return value.ToUInt16(provider);
    		}
    		if (left == Convert.ConvertTypes[9])
    		{
    			return value.ToInt32(provider);
    		}
    		if (left == Convert.ConvertTypes[10])
    		{
    			return value.ToUInt32(provider);
    		}
    		if (left == Convert.ConvertTypes[11])
    		{
    			return value.ToInt64(provider);
    		}
    		if (left == Convert.ConvertTypes[12])
    		{
    			return value.ToUInt64(provider);
    		}
    		if (left == Convert.ConvertTypes[13])
    		{
    			return value.ToSingle(provider);
    		}
    		if (left == Convert.ConvertTypes[14])
    		{
    			return value.ToDouble(provider);
    		}
    		if (left == Convert.ConvertTypes[15])
    		{
    			return value.ToDecimal(provider);
    		}
    		if (left == Convert.ConvertTypes[16])
    		{
    			return value.ToDateTime(provider);
    		}
    		if (left == Convert.ConvertTypes[18])
    		{
    			return value.ToString(provider);
    		}
    		if (left == Convert.ConvertTypes[1])
    		{
    			return value;
    		}
    		if (left == Convert.EnumType)
    		{
    			return (Enum)value;
    		}
    		if (left == Convert.ConvertTypes[2])
    		{
    			throw new InvalidCastException(Environment.GetResourceString("InvalidCast_DBNull"));
    		}
    		if (left == Convert.ConvertTypes[0])
    		{
    			throw new InvalidCastException(Environment.GetResourceString("InvalidCast_Empty"));
    		}
    	}
    	throw new InvalidCastException(Environment.GetResourceString("InvalidCast_FromTo", new object[]
    	{
    		value.GetType().FullName, 
    		targetType.FullName
    	}));
    }
