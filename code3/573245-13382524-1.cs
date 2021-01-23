    class MyThread : Thread
    {
        int _hz;
        A _instance;
        
        public void MyThread(A inst){
            _instance = inst;
        }
    
        void computeFrequency()
        {
            //changesHZField...
            _instance.Signal(_hz);
        }
    }
