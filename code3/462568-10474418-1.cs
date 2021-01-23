    object timeCheck= new object();
    void Timer()
    {
        Monitor.TryEnter(timeCheck) 
        {
            //Code that might take too long 
            //...
            Monitor.Exit();
        }
    }
