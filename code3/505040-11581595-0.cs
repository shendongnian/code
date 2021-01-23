    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            if (backgroundWorker1.CancellationPending)
            {
                break;
            }
            else
            {
                // Do whatever you're doing.
            }
        }
        e.Result = backgroundWorker1.CancellationPending ? null : orders;
    }
