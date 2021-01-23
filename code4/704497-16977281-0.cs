        static readonly object _lock = new object();
        static SomeClass sc;
        static void workerMethod()
        {
            //assuming this method is called by multiple threads
            longProcessingMethod();
            sc = new SomeClass();
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
