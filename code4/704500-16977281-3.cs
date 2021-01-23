        static readonly object _lock = new object();
        static SomeClass sc = new SomeClass();
        static void workerMethod()
        {
            //assuming this method is called by multiple threads
            longProcessingMethod();
            
            modifySharedResource(sc);
        }
        static void modifySharedResource(SomeClass sc)
        {
            //do something
            lock (_lock)
            {
                //where sc is modified
            }
        }
        static void longProcessingMethod()
        {
            //a long process
        }
