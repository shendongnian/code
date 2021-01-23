    void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        label1.Text = e.Result.ToString(); // getting the result set in DoWork
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        int value = 0;
            
        for (int i = 0; i < 10; i++)
            value++;
        e.Result = value; // setting result for RunWorkerCompleted
    }
