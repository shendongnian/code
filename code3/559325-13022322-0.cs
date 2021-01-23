    static void Main (string [] args)
    {
    	int batch_size = 5;
    	string buffer = "";
    	foreach (var c in EnumerateString("THISISALONGSTRING")) 
    	{				
    		// Check if it's time to split the batch
    		if (buffer.Length >= batch_size) 
    		{
    			// Process the batch
    			buffer = ProcessBuffer(buffer);
    		}
		
    		// Add to the buffer
    		buffer += c;
    	}
	
    	// Process the remaining items
    	ProcessBuffer(buffer);
	
    	Console.ReadLine();
    }
    public static string ProcessBuffer(string buffer)
    {
    	Console.WriteLine(buffer);	
    	return "";
    }
    public static IEnumerable<char> EnumerateString(string huh)
    {
        for (int i = 0; i < huh.Length; i++) {
    		Console.WriteLine("yielded: " + huh[i]);
    		yield return huh[i];
    	}
    }
