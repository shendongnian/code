    string line;
    using (StreamReader reader = new StreamReader("file.txt"))
    {
    	line = reader.ReadLine();
    
    	if(line.Contains("90312"))
    	{
    	  // Do something fancy here.
    	}
    }
