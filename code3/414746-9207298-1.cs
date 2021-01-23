    public event ProgressChangedEventHandler ProgressChanged;
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (ProgressChanged != null) {
            ProgressChanged(this, e);
        }
    }
