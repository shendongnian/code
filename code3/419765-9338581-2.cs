    private static void InternalWriteAllText(string path, string contents, Encoding encoding)
    {
    	using (StreamWriter streamWriter = new StreamWriter(path, false, encoding))
    	{
    		streamWriter.Write(contents);
    	}
    }
