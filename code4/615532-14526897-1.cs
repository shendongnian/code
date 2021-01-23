    public class ViewModel 
    {
    	BackgroundWorker _primeWorker;
    
    	public ViewModel()
    	{
    		_primeWorker = new BackgroundWorker;
    
    		_primeWorker.DoWork += ...
    	}
        
        public void AddSomeNumbers()
        {
             if(_primerWorker.IsBusy == false)
                  _primeWorker.RunWorkerAsync();
        }
    }
