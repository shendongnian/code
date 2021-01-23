    class B 
    {  
        public event MyDelegate MyEvent;
     
        protected OnMyEvent(int p_Arg)
        {
            // Delegates are immutable and add/remove default
            // implementations always generate a new instance of the 
            // delegate. Therefore, tTmp (if not null) can be safely invoked
            var tTmp = 
                System.Threading.Interlocked
                .CompareExchange(ref MyEvent, null, null);
            if (tTmp != null) {
                tTmp(p_Arg);
            }
        }
    
        //Assume this runs in a new thread and calls back data using MyEvent 
        //Have ommited thread code for simplicity 
        public void Run() 
        { 
            for (int i = 0; i < 100; i++) 
            { 
                OnMyEvent(i);
            }    
        } 
    } 
