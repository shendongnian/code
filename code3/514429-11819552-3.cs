    // System.Numerics.BigInteger
    /// <summary>Converts a <see cref="T:System.Numerics.BigInteger" /> value to a byte array.</summary>
    /// <returns>The value of the current <see cref="T:System.Numerics.BigInteger" /> object converted to an array of bytes.</returns>
    public byte[] ToByteArray()
    {
    	if (this._bits == null && this._sign == 0)
    	{
    		return new byte[1];
    	}
    	uint[] array;
    	byte b;
    	if (this._bits == null)
    	{
    		array = new uint[]
    		{
    			(uint)this._sign
    		};
    		b = ((this._sign < 0) ? 255 : 0);
    	}
    	else
    	{
    		if (this._sign == -1)
    		{
    			array = (uint[])this._bits.Clone();
    			NumericsHelpers.DangerousMakeTwosComplement(array);
    			b = 255;
    		}
    		else
    		{
    			array = this._bits;
    			b = 0;
    		}
    	}
    	byte[] array2 = new byte[checked(4 * array.Length)];
    	int num = 0;
    	for (int i = 0; i < array.Length; i++)
    	{
    		uint num2 = array[i];
    		for (int j = 0; j < 4; j++)
    		{
    			array2[num++] = (byte)(num2 & 255u);
    			num2 >>= 8;
    		}
    	}
    	int num3 = array2.Length - 1;
    	while (num3 > 0 && array2[num3] == b)
    	{
    		num3--;
    	}
    	bool flag = (array2[num3] & 128) != (b & 128);
    	byte[] array3 = new byte[num3 + 1 + (flag ? 1 : 0)];
    	Array.Copy(array2, array3, num3 + 1);
    	if (flag)
    	{
    		array3[array3.Length - 1] = b;
    	}
    	return array3;
    }
