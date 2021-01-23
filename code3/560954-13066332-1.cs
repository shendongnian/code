    public void HandleFileChanged(object source, FileSystemEventArgs e)
    {
        HandleFileChange(<path and file>);
    }
    public void timer1_Tick(object source, EventArgs e)
    {
        HandleFileChange(<path and file>);
    }
    private void HandleFileChange(string pathAndFile)
    {
        // Do what you have to do
    }
