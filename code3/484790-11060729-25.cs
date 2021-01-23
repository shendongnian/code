    //This is another part of the same class
    //This one includes GetConnection
    public partial class YourClass
    {
        //1 if GetConnection has been called, 0 otherwise
        private int _initializingServiceObject;
        public void GetConnection(string thread)
        {
            if (Interlocked.CompareExchange(ref _initializingServiceObject, 1, 0) == 0)
            {
                //Go on, it is the first time GetConnection is called
                
                //I found that ops is not being used
                //ParallelOptions ops = new ParallelOptions();
                if(thread.Equals("one"))
                {
                    Parallel.For(0, 1, i =>
                    {
                        //It seems to me a good idea to take the same path here too
                        //dynamic serviceObject = InitializeCRMService();
                        Store(InitializeCRMService());
                    });
                }
                else if (thread.Equals("multi"))
                {
                    ThreadPool.QueueUserWorkItem
                    (
                         new WaitCallback
                         (
                             (_) =>
                             {
                                  Store(InitializeCRMService());
                             }
                         )
                    );
                }
            }
        }
    }
