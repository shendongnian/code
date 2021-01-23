    public event ProgressChangedEventHandler ProgressChanged;
    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        int update = e.ProgressPercentage;
        myForm.BeginInvoke(myForm.myDelegate, update);
        if (ProgressChanged != null) {
            ProgressChanged(this, e);
        }
    }
