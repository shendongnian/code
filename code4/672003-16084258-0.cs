	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    	try
   		{
        	BackgroundWorker worker = sender as BackgroundWorker;
         	throw new Exception("TEST EXCEPTION!");
    	}
    	catch(Exception ex)
    	{
    		e.Result = ex;
    	}
    }
    
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Result is Exception)
        {
            throw e.Result;
        }
	}
