        private BackgroundWorker assignmentWorker;
        private void InitializeBackgoundWorkers() {
            assignmentWorker = new BackgroundWorker();
            assignmentWorker.DoWork += AssignmentWorkerOnDoWork;
            // ...
        }
        private void AssignmentWorkerOnDoWork( object sender, DoWorkEventArgs doWorkEventArgs ) {
            for( var f = 0; f < FilesToProcess; f++ ) {
                var fileProcessed = false;
                while( !fileProcessed ) {
                    for( var threadNum = 0; threadNum < MaxThreads; threadNum++ ) {
                        if( !threadArray[threadNum].IsBusy ) {
                            Console.WriteLine( "Starting Thread: {0}", threadNum );
                            threadArray[threadNum].RunWorkerAsync( f );
                            fileProcessed = true;
                            break;
                        }
                    }
                    if( !fileProcessed ) {
                        Thread.Sleep( 50 );
                        break;
                    }
                }
            }
        }
        private void button1_Click( object sender, EventArgs e ) {
            assignmentWorker.RunWorkerAsync();
        }
