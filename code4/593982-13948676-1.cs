    bool output = false;
    foreach (var line in File.ReadLines("C:\\test.txt"))
    {
        if (!output && line.Contains("beginText"))
    	{
    	    output = true;
    	}
    	else if (output && line.Contains("endText"))
    	{
    	    break;
    	}
    	
    	if (output)
    	{
    	    Console.WriteLine(line);
    	}
    }
