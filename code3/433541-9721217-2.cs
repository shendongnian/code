    // Declare your process object with WithEvents, so that events can be handled.
    private Process withEventsField_MyProcess;
    Process MyProcess {
    	get { return withEventsField_MyProcess; }
    	set {
    		if (withEventsField_MyProcess != null) {
    			withEventsField_MyProcess.Exited -= MyProcess_Exited;
    		}
    		withEventsField_MyProcess = value;
    		if (withEventsField_MyProcess != null) {
    			withEventsField_MyProcess.Exited += MyProcess_Exited;
    		}
    	}
    }
    
    bool MyProcessIsRunning;
    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
    	// start the process. this is an example.
    	MyProcess = Process.Start("Notepad.exe");
    
    	// enable raising events for the process.
    	MyProcess.EnableRaisingEvents = true;
    
    	// set the flag to know whether my process is running
    	MyProcessIsRunning = true;
    }
    
    private void MyProcess_Exited(object sender, System.EventArgs e)
    {
    	// the process has just exited. what do you want to do?
    	MyProcessIsRunning = false;
    	MessageBox.Show("The process has exited!");
    }
