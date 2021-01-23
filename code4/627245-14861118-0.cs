        class ServerStuff
    {
        public void Init()
        {
            datatosend = new List<string>();
                        exitrequest = new EventWaitHandle(false, EventResetMode.ManualReset); //This wait handle will signal the consumer thread to exit
            Thread t = new Thread(new ThreadStart(_RunThread));
            t.Start(); // Start the consumer thread...
        }
        public void Stop()
        {
            exitrequest.Set();
        }
        List<string> datatosend;
        EventWaitHandle exitrequest;
        public void AddItem(string item)
        {
            lock (((ICollection)datatosend).SyncRoot)
                datatosend.Add(item);
        }
        private void RunThread()
        {
            while (exitrequest.WaitOne(10 * 1000)) //wait 10 seconds between sending data, or wake up immediatly to exit request
            {
                string[] tosend;
                lock (((ICollection)datatosend).SyncRoot)
                {
                    tosend = datatosend.ToArray();
                    datatosend.Clear();
                }
                //Send the data to Sever here...
            }
        }
    }
