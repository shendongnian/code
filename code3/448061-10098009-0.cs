    // The event...
    public EventHandler<FileDetectedEventArgs> NewFileDetected;
    // Note the naming
    protected void OnNewFileDetected(FileDetectedEventArgs e)
    {
        // Note this pattern for thread safety...
        EventHandler<FileDetectedEventArgs> handler = this.NewFileDetected; 
        if (handler != null)
        {
            handler(this, e);
        }
    }
