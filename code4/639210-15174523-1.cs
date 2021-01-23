    // string
    /// <summary>
    ///               Returns the hash code for this string.
    ///           </summary>
    /// <returns>
    ///               A 32-bit signed integer hash code.
    ///           </returns>
    /// <filterpriority>2</filterpriority>
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public unsafe override int GetHashCode()
    {
    	IntPtr arg_0F_0;
    	IntPtr expr_06 = arg_0F_0 = this;
    	if (expr_06 != 0)
    	{
    		arg_0F_0 = (IntPtr)((int)expr_06 + RuntimeHelpers.OffsetToStringData);
    	}
    	char* ptr = arg_0F_0;
    	int num = 352654597;
    	int num2 = num;
    	int* ptr2 = (int*)ptr;
    	for (int i = this.Length; i > 0; i -= 4)
    	{
    		num = ((num << 5) + num + (num >> 27) ^ *ptr2);
    		if (i <= 2)
    		{
    			break;
    		}
    		num2 = ((num2 << 5) + num2 + (num2 >> 27) ^ ptr2[(IntPtr)4 / 4]);
    		ptr2 += (IntPtr)8 / 4;
    	}
    	return num + num2 * 1566083941;
    }
