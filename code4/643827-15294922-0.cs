    // int
    /// <summary>Converts the string representation of a number to its 32-bit signed integer equivalent. A return value indicates whether the operation succeeded.</summary>
    /// <returns>true if s was converted successfully; otherwise, false.</returns>
    /// <param name="s">A string containing a number to convert. </param>
    /// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent to the number contained in s, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the s parameter is null, is not of the correct format, or represents a number less than <see cref="F:System.Int32.MinValue"></see> or greater than <see cref="F:System.Int32.MaxValue"></see>. This parameter is passed uninitialized. </param>
    /// <filterpriority>1</filterpriority>
    public static bool TryParse(string s, out int result)
    {
    	return Number.TryParseInt32(s, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
    }
    // System.Number
    internal unsafe static bool TryParseInt32(string s, NumberStyles style, NumberFormatInfo info, out int result)
    {
    	byte* stackBuffer = stackalloc byte[1 * 114 / 1];
    	Number.NumberBuffer numberBuffer = new Number.NumberBuffer(stackBuffer);
    	result = 0;
    	if (!Number.TryStringToNumber(s, style, ref numberBuffer, info, false))
    	{
    		return false;
    	}
    	if ((style & NumberStyles.AllowHexSpecifier) != NumberStyles.None)
    	{
    		if (!Number.HexNumberToInt32(ref numberBuffer, ref result))
    		{
    			return false;
    		}
    	}
    	else
    	{
    		if (!Number.NumberToInt32(ref numberBuffer, ref result))
    		{
    			return false;
    		}
    	}
    	return true;
    }
