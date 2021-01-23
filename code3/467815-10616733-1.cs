	// Get a temp file
	string tempFilepath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "MyBatchFile.bat");
	// Ensure the file dont exists yet
	if (System.IO.File.Exists(tempFilepath)) {
		System.IO.File.Delete(tempFilepath);
	}
	// Create some operations
	string[] batchOperations = new string[]{
		"START netstat -a",
		"START systeminfo"
	};
	// Write the temp file
	System.IO.File.WriteAllLines(tempFilepath, batchOperations);
	// Create process
	Process myProcess = new Process();
	try {
		// Full filepath to the temp file
		myProcess.StartInfo.FileName = tempFilepath;
		// Execute it
		myProcess.Start();
		// This code assumes the process you are starting will terminate itself!
	} catch (Exception ex) {
		// Output any error to the console
		Console.WriteLine(ex.Message);
	}
	// Remove the temp file
	System.IO.File.Delete(tempFilepath);
