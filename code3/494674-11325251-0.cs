    using (var mmf = 
    			MemoryMappedFile.CreateFromFile(@"c:\large.data", FileMode.Open
    {
    	using (MemoryMappedViewStream stream = mmf.CreateViewStream())
    	{
    		TextReader tr = new StreamReader(stream);
    		while ((line = sr.ReadLine()) != null) 
    		{
    			Console.WriteLine(line);
    		}
    	}
    }
