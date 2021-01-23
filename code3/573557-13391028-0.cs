    private void button3_Click(object sender, EventArgs e)
        {
            ProcessingEvent += AnEventOccurred;
            ThreadStart threadStart = new ThreadStart(LongRunningProcess);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
        private void LongRunningProcess()
        {
            RaiseEvent("Start");
            for (int i = 0; i < 10; i++)
            {
                RaiseEvent("Processing " + i);
                Thread.Sleep(1000);
            }
            if (ProcessingEvent != null)
            {
                ProcessingEvent("Complete");
            }
        }
        private void RaiseEvent(string whatOccurred)
        {
            if (ProcessingEvent != null)
            {
                ProcessingEvent(whatOccurred);
            }
        }
        private void AnEventOccurred(string whatOccurred)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Processing(AnEventOccurred), new object[] { whatOccurred });
            }
            else
            {
                this.label1.Text = whatOccurred;
            }
        }
        delegate void Processing(string whatOccurred);
        event Processing ProcessingEvent;
