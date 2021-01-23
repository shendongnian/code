    private void Calculate(int i)
    {
    	double pow = Math.Pow(i, i);
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    	progressBar1.Maximum = 100;
    	progressBar1.Step = 1;
    	progressBar1.Value = 0;
    	backgroundWorker.RunWorkerAsync();
    }
    
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
    	var backgroundWorker = sender as BackgroundWorker;
    	for (int j = 0; j < 100000; j++)
    	{
    		Calculate(j);
    		backgroundWorker.ReportProgress((j * 100) / 100000);
    	}
    }
    
    private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	progressBar1.Value = e.ProgressPercentage;
    }
    
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	// TODO: do something with final calculation.
    }
