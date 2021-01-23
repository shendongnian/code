    //
	// Start the process.
	//
	using (Process process = Process.Start(start))
	{
	    //
	    // Read in all the text from the process with the StreamReader.
	    //
	    using (StreamReader reader = process.StandardOutput)
	    {
		string result = reader.ReadToEnd();
		Console.Write(result);
	    }
	}
