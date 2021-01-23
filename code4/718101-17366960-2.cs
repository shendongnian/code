    public void executeCommandFiles()
    {
    	foreach (string test in listboxTestsToRun.Items)
    	{
    		//gets the directory name from given filename (filename without extension)
    		//assumes that only the last '.' is for the extension. test.1.cmd => test.1
    		string testName = test.Substring(0, test.LastIndexOf('.')); 
    
    		//set up a FileInfo object so we can make sure the test exists gracefully.
    		FileInfo testFile = new FileInfo(@"Y:\Tests\" + testName + "\\" + test);
    
    		//check if it is a valid path
    		if (testFile.Exists)
    		{
    			ProcessStartInfo startInfo = new ProcessStartInfo(testFile.FullName);
    			//get the Process object so we can wait for it to finish.
    			Process currentTest = Process.Start(startInfo);
    			//wait 5 minutes then timeout (5m * 60s * 1000ms)
    			bool completed = currentTest.WaitForExit(300000);
    			if (!completed)
    				MessageBox.Show("test timed out");
    			//use this if you want to wait for the test to complete (indefinitely)
    			//currentTest.WaitForExit();
    		}
    		else
    		{
    			MessageBox.Show("Error: " + testFile.FullName + " was not found.");
    		}
    	}
    }
        
