    using System;
    using System.Threading;
    
    public class Worker
    {
        // This method will be called when the thread is started.
        public void DoWork()
        {
            while (!_shouldStop)
            {
                // do tasks...
                Thread.Sleep(300000);
            }
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
    
        private volatile bool _shouldStop;
    }
    
    public class WorkerThreadExample
    {
        static void Main()
        {
            // Create the thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);
    
            // Start the worker thread.
            workerThread.Start();
           
            // Loop until worker thread activates.
            while (!workerThread.IsAlive);
            
            while (true)
            {
                //do something to make it break
            }
            
            // Request that the worker thread stop itself:
            workerObject.RequestStop();
            workerThread.Join();
        }
    }
