     private void callBack(IAsyncResult itfAR)
        {
            Console.WriteLine("Current thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            myConnection.BeginInvoke(callBack, this);
            Thread.Sleep(100000);
        }
