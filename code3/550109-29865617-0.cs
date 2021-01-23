    class MyTimer {
        private readonly System.Timers.Timer timer;
        private static AutoResetEvent elapsedOutputted = new AutoResetEvent(false);
        //private static AutoResetEvent mainReady = new AutoResetEvent(true);
        public MyTimer(ISynchronizeInvoke synchronizingObject) {
           
            Console.Out.WriteLine(Thread.CurrentThread.ManagedThreadId);
            timer = new System.Timers.Timer(1000);
            timer.SynchronizingObject = synchronizingObject;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            //timer.Stop(); not needed
            Console.Out.WriteLine(Thread.CurrentThread.ManagedThreadId);
            elapsedOutputted.Set();
            //Thread.Sleep(2000); not needed
            //timer.Start(); not needed
        }
        static void Main(string[] args) {
            Control c = new Control();
            IntPtr tempNotUsed = c.Handle;
            var mytimer = new MyTimer(c);
            for (int runs = 0; runs < 10; runs++) {
                while (!elapsedOutputted.WaitOne(1000)) { //this will deadlock, but the 1000ms timeout will free it
                    Application.DoEvents(); //not sure if DoEvents is the best idea, but it does the trick
                } //end while
            } //end for
        } //end Main
    } //end class
