    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.startFeed();
        }
        // This is run on the main thread
        public void startFeed()
        {
            // Start a Timer on a new thread to do work with the ProcessData method
            // Pass null to its 'state' argument, wait 0 milliseconds before
            // running it, and run it once every 300000 milliseconds
            using (new Timer(ProcessData, null, 0, 300000))
            {
                // The Timer will only exist while we are inside the 'using' block;
                // stay here with a loop
                while (true)
                {
                    // Write our status message
                    Console.WriteLine("Waiting for data at {0}...", DateTime.Now);
                    // We don't want this loop running ALL the time; add a small
                    // delay so it only updates once every second
                    Thread.Sleep(1000); 
                }
            }
        }
        // This is run on the background thread
        private void ProcessData(object state)
        {
            try
            {
                //My Application which i want to run continously 
                //when thread enters in run mode
            }
            catch (Exception xObj)
            {
                Console.WriteLine(DateTime.Now.ToString()
                    + " >> Incoming Message Processing Error. >> "
                    + xObj.Message);
            }
        }
    }
