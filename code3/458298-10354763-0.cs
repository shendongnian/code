    private static void CopyFile(string source, string destination, int bytesPerChunk)
    {
        int bytesRead = 0;
    	
    	using (FileStream fs = new FileStream(source, FileMode.Open, FileAccess.Read))
    	{
    		using (BinaryReader br = new BinaryReader(fs))
    		{
    			using (FileStream fsDest = new FileStream(destination, FileMode.Create))
    			{
    				BinaryWriter bw = new BinaryWriter(fsDest);
    				byte[] buffer;
    
    				for (int i = 0; i < fs.Length; i += bytesPerChunk)
    				{
    					buffer = br.ReadBytes(bytesPerChunk);
    					bw.Write(buffer);
    					bytesRead += bytesPerChunk;
    					ReportProgress(bytesRead, fs.Length);  //report the progress
    				}
    			}
    		}
    	}
    }
