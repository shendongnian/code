    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    	BackgroundWorker worker = sender as BackgroundWorker;
    
    	for (int i = 1; i <= 10; i++)
    	{
    		if (worker.CancellationPending == true)
    		{
    			e.Cancel = true;
    			break;
    		}
    		else
    		{
    			//// your code here
    		}
    	}
    }
