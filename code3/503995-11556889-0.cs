    var targetDirectory = "Put your dir here";
    var minDate = DateTime.Today.AddDays(-1);
    var maxDate = DateTime.Today.AddSeconds(-1);
	try
	{
		var dir = new Directory(targetDirectory);
		foreach (var file in dir.GetFiles().Where(f => f.CreationTime >= minDate 
                                                    && f.CreationTime <= maxDate))
		{
			// Do something with file.
			Console.WriteLine("File : {0}", file.FullName);
		}
	}
	catch( Exception e )
	{
		// Handle access exceptions.
	}
