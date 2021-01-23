    public static int ToInt32(double value)
    {
    	if (value >= 0.0)
    	{
    		if (value < 2147483647.5)
    		{
    			int num = (int)value;
    			double num2 = value - (double)num;
    			if (num2 > 0.5 || (num2 == 0.5 && (num & 1) != 0))
    			{
    				num++;
    			}
    			return num;
    		}
    	}
    	else
    	{
    		if (value >= -2147483648.5)
    		{
    			int num3 = (int)value;
    			double num4 = value - (double)num3;
    			if (num4 < -0.5 || (num4 == -0.5 && (num3 & 1) != 0))
    			{
    				num3--;
    			}
    			return num3;
    		}
    	}
    	throw new OverflowException(Environment.GetResourceString("Overflow_Int32"));
    }
