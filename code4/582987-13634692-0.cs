    private void ThreadTask()
    {
        while (true)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ThreadStart(SetRandomProgress));
            }
            else
            {
                SetRandomProgress();
            }
            
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
