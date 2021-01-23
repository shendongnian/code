    protected void getData()
    {
    	try
            {	// Make a code to get the data from data base here and then for varbinary fild I have used "fieldName"
    		string contents = (byte[])ds.Tables[0].Rows[0]["fieldName"];
    		editor.Content = new GetString(excelContents);
    	}
    	catch (Exception ex)
            {
                    throw ex;
            }
    }
    
    public static string GetString(byte[] bytes)
    {
    	try
            {
                char[] chars = new char[bytes.Length / sizeof(char)];
                System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
                return new string(chars);
    	}
    	catch (Exception ex)
            {
                    throw ex;
            }
    }
