    private void ThreadTask()
    {
        // This code runs in the background thread.
        while (true)
        {
            if (this.InvokeRequired)
            {
                // In order to access the UI controls, we must Invoke back to the UI thread
                this.Invoke(new ThreadStart(SetRandomProgress));
            }
            else
            {
                // We are already in the UI thread, so we don't have to Invoke
                SetRandomProgress();
            }
            
            // Wait briefly.  This wait happens in the background thread.
            // During this time, the UI is still responsive, because it is not blocked.
            // You can verify this by tweaking the duration to something longer (say, 5000 ms).
            Thread.Sleep(100);
        }
    }
    private void SetRandomProgress()
    {
        Random rnd = new Random();
        int stp = this.progressBar1.Step * rnd.Next(-1, 2);
        int newval = this.progressBar1.Value + stp;
        if (newval > this.progressBar1.Maximum)
            newval = this.progressBar1.Maximum;
        else if (newval < this.progressBar1.Minimum)
            newval = this.progressBar1.Minimum;
        this.progressBar1.Value = newval;
    }
