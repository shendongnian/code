    private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
    {
        var flow = new Flow(_worker);
        flow.NaturalNumbers();
    }
    internal class Flow
    {
        private readonly BackgroundWorker _worker;
        public Flow(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Flow(BackgroundWorker worker)
        {
            _worker = worker;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int NaturalNumbers()
        {
            for (int i = 0; i <= 9999; i++)
            {
                int iteration = i*100/9999;
                // your if(...) fails with divide by zero exception
                _worker.ReportProgress(iteration);
            }
            return 1;
        }
    }
