        delegate void ThreadTaskDelegate();
        private void ThreadTask()
        {
            if (this.InvokeRequired)
            {
                ThreadTaskDelegate del = new ThreadTaskDelegate(ThreadTask);
                this.Invoke(del, null);
            }
            else
            {
                int stp;
                int newval;
                Random rnd = new Random();
                while (true)
                {
                    stp = this.progressBar1.Step * rnd.Next(-1, 2);
                    newval = this.progressBar1.Value + stp;
                    if (newval > this.progressBar1.Maximum)
                        newval = this.progressBar1.Maximum;
                    else if (newval < this.progressBar1.Minimum)
                        newval = this.progressBar1.Minimum;
                    this.progressBar1.Value = newval;
                    Thread.Sleep(100);
                }
            }
        }
