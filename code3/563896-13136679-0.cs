    public void SampleAsync()
        {
            AsyncManager.OutstandingOperations.Increment();
            for(int i=0; i=100000; i++)
            {
             
            }
            AsyncManager.Parameters["myvariable"] = "variable value";
            AsyncManager.OutstandingOperations.Decrement();        
        }
    
        public ActionResult SampleCompleted(string myvariable)
        {
            //myvariable contains value "variable value"
            return result;
        }
