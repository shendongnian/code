    BackgroundWorker backgroundWorker1;     
        Random ran;
        long runningThreads = 0;
        public void Start()     
        {         
            method();         
           // Console.WriteLine("Threads is finished");     
        }       
        private void method() // recursive method     
        {
            Interlocked.Increment(ref runningThreads);
            Console.WriteLine("New thread started");
            Thread.Sleep(100);              
            backgroundWorker1 = new BackgroundWorker();              
            backgroundWorker1.DoWork +=                 
                new DoWorkEventHandler(backgroundWorker1_DoWork);             
            backgroundWorker1.RunWorkerAsync();               //Beginning new thread     
        }      
        private void backgroundWorker1_DoWork(object sender,        DoWorkEventArgs e)     
        {             
            ran = new Random();             
            Thread.Sleep(ran.Next(500, 1000));             
            if (ran.Next(1, 5) != 1) // if = 1 then to stop recursion             
            {                 
                method();             
            }
            Finished();
        }
        private void Finished()
        {
            Interlocked.Decrement(ref runningThreads);
            if (Interlocked.Read(ref runningThreads) == 0)
            {
                Console.WriteLine("Threads is finished");     
 
            }
        }
