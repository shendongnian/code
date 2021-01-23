    public class MyForm
    {
        private BackgroundWorker _worker;
        public MyForm()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += (s, args) =>
            {
                var timer = Stopwatch().StartNew();
                timer.Start();
                do
                {
                    // do something
                } while (timer.ElapsedMilliseconds < 60000)
            };
        }
    }
