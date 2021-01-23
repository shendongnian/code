    public static Byte[] ReadMMFAllBytes(string fileName)
    {
    	using (var mmf = MemoryMappedFile.OpenExisting(fileName))
    	{
    		using (var stream = mmf.CreateViewStream())
    		{
    			using (BinaryReader binReader = new BinaryReader(stream))
    			{
    				return binReader.ReadBytes((int)stream.Length));
    			}
    		}
    	}
    }
