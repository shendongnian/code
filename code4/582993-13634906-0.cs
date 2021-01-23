    private void Form1_Load(object sender, EventArgs e)
            {
                Thread trd = new Thread(new ThreadStart(this.ThreadTask));
                trd.IsBackground = true;
                trd.Start();
            }
            private void ThreadTask()
            {
                Random rnd = new Random();
                while (true)
                {
                    int randValue = rnd.Next(-1, 2);
                    progressBar1.Invoke(new updater(UpdateProgressBar), new object[] {randValue});
                    Thread.Sleep(100);
                }
            }
            private delegate void updater(int value);
            private void UpdateProgressBar(int randValue)
            {
                int stp = this.progressBar1.Step * randValue;
                int newval = this.progressBar1.Value + stp;
                if (newval > this.progressBar1.Maximum)
                    newval = this.progressBar1.Maximum;
                else if (newval < this.progressBar1.Minimum)
                    newval = this.progressBar1.Minimum;
                this.progressBar1.Value = newval;
                
            }
