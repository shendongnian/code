    public delegate void FileCompleteHandler(object sender, EventArgs e)
    public class ClassNameHere
    {
        protected virtual void OnFileComplete()
        {
            FileCompleteHandler handler = FileComplete;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public void doWork(IEnumerable<string> source, int parallelThreads )
        {
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Parallel.ForEach(source,
                        new ParallelOptions
                        {
                            MaxDegreeOfParallelism = parallelThreads //limit number of parallel threads 
                        },
                        file =>
                        {
                            if (token.IsCancellationRequested)
                                return;
                            //do work...
                            // This is where we tell the UI to update itself.
                            OnFileComplete();
                        });
                }
                catch (Exception)
                { }
            }, _tokenSource.Token).ContinueWith(
                    t =>
                    {
                        //finish...
                    }
                , TaskScheduler.FromCurrentSynchronizationContext() //to ContinueWith (update UI) from UI thread
                );
        } 
        
        public event FileCompleteHandler FileComplete;
    }
