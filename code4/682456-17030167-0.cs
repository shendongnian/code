    using (var fs = new FileStream(filePath, FileMode.Open))
    using (var reader = new StreamReader(fs))
    {
    	string line;
    	while ((line = reader.ReadLine()) != null)
    	{
    		if (line.StartsWith("INFO"))
    		{
    			line = Regex.Replace(line, "[ ]+", "_");
    			var subline = line.Split('_');
    
    			foreach (var str in subline)
    			{
    				Console.Write("{0} ",str);
    			}
    			Console.WriteLine();
    		}
    
    	}
    	
    }
