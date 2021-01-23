    public byte[] FileToByteArray(string _FileName)
    {
    	byte[] _Buffer = null;
     
    	try
    	{
    		System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
    		System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);
    		long _TotalBytes = new System.IO.FileInfo(_FileName).Length;
    		_Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);
    		_FileStream.Close();
    		_FileStream.Dispose();
    		_BinaryReader.Close();
    	}
    	catch (Exception _Exception)
    	{
    		Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
    	}
    	return _Buffer;
    }
