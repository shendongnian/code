    public class ProgressEventArgs : EventArgs
    {
    	public int Value { get; set; }
    
    	public int Max { get; set; }
    
    	public int Min { get; set; }
    }
    
    public class Worker
    {
    	public delegate void ProgressUpdatedEventHandler(object sender, ProgressEventArgs e);
    
    	public event ProgressUpdatedEventHandler ProgressUpdated;
    
    	public event EventHandler WorkDone;
    
    	public void Start()
    	{
    		Thread workerThread = new Thread(new ThreadStart(this.DoWork));
    		workerThread.Start();
    	}
    
    	private void DoWork()
    	{
    		int min = 0;
    		int max = 1000000;
    
    		for (int i = min; i < max; i++)
    		{
    			// Simulates work
    			////System.Threading.Thread.Sleep(1);
    
    			// Notify of progress update
    			////this.OnProgressUpdate(min, max, i);
    
    			// Notify of progress update but not every time to save CPU time
    			// Uses mod function to do the job 1 out of 100 times
    			if (i % 100 == 0)
    			{
    				this.OnProgressUpdate(min, max, i);
    			}
    		}
    
    		// Notify the work is done
    		if (this.WorkDone != null)
    		{
    			this.WorkDone(this, EventArgs.Empty);
    		}
    	}
    
    	private void OnProgressUpdate(int min, int max, int value)
    	{
    		if (this.ProgressUpdated != null)
    		{
    			this.ProgressUpdated(this, new ProgressEventArgs { Max = max, Min = min, Value = value });
    		}
    	}
    }
