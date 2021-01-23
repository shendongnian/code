        static void Main( string[] args )
        {
            var bg = new BackgroundWorker { WorkerSupportsCancellation = true };
            bg.DoWork += LongRunningTask;
            const int Timeout = 500;
            Action a = () =>
                {
                    Thread.Sleep( Timeout );
                    bg.CancelAsync();
                };
            a.BeginInvoke( delegate { }, null );
            bg.RunWorkerAsync();
            Console.ReadKey();
        }
        private static void LongRunningTask( object sender, DoWorkEventArgs eventArgs )
        {
            var worker = (BackgroundWorker)sender;
            foreach ( var i in Enumerable.Range( 0, 5000 ) )
            {
                if ( worker.CancellationPending )
                {
                    return;
                }
                else
                {
                    //Keep working
                }
            }
        }
