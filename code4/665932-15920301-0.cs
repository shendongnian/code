    public static byte[] DateToBytes(DateTime _Date)
    {
    	using (System.IO.MemoryStream MS = new System.IO.MemoryStream()) {
    		BinaryFormatter BF = new BinaryFormatter();
    		BF.Serialize(MS, _Date);
    		return MS.GetBuffer();
    	}
    }
    
    public static DateTime BytesToDate(byte[] _Data)
    {
    	using (System.IO.MemoryStream MS = new System.IO.MemoryStream(_Data)) {
    		MS.Seek(0, SeekOrigin.Begin);
    		BinaryFormatter BF = new BinaryFormatter();
    		return (DateTime)BF.Deserialize(MS);
    	}
    }
    
