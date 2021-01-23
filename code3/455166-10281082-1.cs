    public void ProcessMessage(string message)
    {
	    switch(message) {
		    case "a0a1a2": Console.WriteLine("1"); break;
		    case "a1a2a0": Console.WriteLine("2"); break;
		    case "a2a1a0": Console.WriteLine("3"); break;
	    }
    }
