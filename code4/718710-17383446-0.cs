    public string ConvertHexToString(string hexInput, System.Text.Encoding encoding)
	{
	    int numberChars = hexInput.Length;
	    byte[] bytes = new byte[numberChars / 2];
	    for (int i = 0; i < numberChars; i += 2)
	    {
	    	bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
	    }
	 	return encoding.GetString(bytes);
	}
