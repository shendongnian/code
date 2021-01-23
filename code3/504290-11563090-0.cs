	public static bool IsEqualWithoutWhiteSpace(this string aLhs, string aRhs)
	{
		var left = aLhs.Trim();
		var right = aRhs.Trim();
		return left.Equals(right, StringComparison.OrdinalIgnoreCase);
	}
    string str1 = "   Abc   ";
    string str2 = "abc";
    
    var b = str1.IsEqualWithoutWhiteSpace(str2);
