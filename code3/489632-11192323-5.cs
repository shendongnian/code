    public ResultForm() {
        // initialization of the GUI form
        InitializeComponent();
    
        [...]
        this.Load += ResultForm_Load;
    }
    
    
    protected void ResultForm_Load(object sender, EventArgs e)
    {
        // watcher for the log files
        logsWatcher= new FileSystemWatcher(LOGFILES_FOLDER);
        logsWatcher.Created += new FileSystemEventHandler(NewFile);
        logsWatcher.EnableRaisingEvents=true;
        //Don't set the synchronization object - now all events from the FileSystemWatcher will be marshalled on a background thread
        Visible = false; //Hide the form if you want or minimize to tray or similar.
    }
    
    private void NewFile (object source, FileSystemEventArgs e) {
        
    	if(InvokeRequired){
    	    //Ensures the file system events are marshalled back to the GUI thread
    	    Invoke(new MethodInvoker(() => {NewFile(source, e);}));
    	    return;
    	}
        
        // make sure the file is of the correct type
        [...]
        // perform some analysis on the file
        [...]
        // update the contents in the form (some TreeViews and labels)
        [...]
    
        // show the form to the user
        Show(); //or Visible = true;
    }
