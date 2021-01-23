	public static byte[] ToByteArray(string value)
	{            
		char[] charArr = value.ToCharArray();
		byte[] bytes = new byte[charArr.Length];
		for (int i = 0; i < charArr.Length; i++)
		{
			byte current = Convert.ToByte(charArr[i]);
			bytes[i] = current;
		}
		return bytes;
	}
