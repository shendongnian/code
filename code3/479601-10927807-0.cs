    private class Data{
        public int Volume {get; set; }      
        private System.Timers.Timer _aliveTimer;
    	
    	public Data() 
    	{	
    		_aliveTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    	}
    	
    	public void Start() 
    	{
    		_aliveTimer.Start();
    	}
    
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("this = " + volume);
        }
    }
    
    Data ret = new Data();
    ret.Volume = rand.Next(1, 10) * 100;    
    ret.Start();
