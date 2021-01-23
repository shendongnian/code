    //delegate method
    private delegate void updateProgressDelegate(int progress);
    
    //actual method
    private void updateProgress(int progress)
    {
        if(this.InvokeRequired)
        {
            this.Invoke(new updateProgressDelegate(updateProgress), progress);
        }
        else
        {
            progressBar.value = progress;
        }
    }
