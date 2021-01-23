    using (var binReader = new System.IO.BinaryReader(System.IO.File.OpenRead("PATHIN")))
    using (var binWriter = new System.IO.BinaryWriter(System.IO.File.OpenWrite("PATHOUT")))
    {
    	byte[] buffer = new byte[512];
    	while (binReader.Read(buffer, 0, 512) != 0)
    	{
    		binWriter.Write(buffer);
    	}
    }
