        private void Form1_Load(object sender, EventArgs e)
        {
            Progress<int> progress = new Progress<int>();
            var task = Alg(progress);
            progress.ProgressChanged += (s, i) => { UpdateProgress(i); };
            task.Start();
        }
        public void UpdateProgress(int iteration)
        {
            progressBar1.PerformStep();
        }
        public static Task Alg(IProgress<int> progress)
        {
            Task t = new Task
            (
                () =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(100);
                        ((IProgress<int>)progress).Report(i);
                    }
                }
            );
            return t;
        }
