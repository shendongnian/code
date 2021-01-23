        public FileTransfer()
        {
            InitializeComponent();
            timer1.Elapsed += timer1_Tick;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            long speed = sumAll - prevSum;
            Console.WriteLine(speed);
            prevSum = sumAll;
            Speed(CnvrtUnit(speed) + "/S");
            if (speed > 0)
            {
                totalSeconds++;
                Timeleft(FormatRemainingText(TimeSpan.FromSeconds((sizeAll - sumAll) / speed)));
                TotalTime(FormatRemainingText(TimeSpan.FromSeconds(totalSeconds)));
            }
        }
        private void Timeleft(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Timeleft), new object[] { value });
                return;
            }
            labelTime.Text = value;
        }
        private void TotalTime(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(TotalTime), new object[] { value });
                return;
            }
            labelTotalTime.Text = value;
        }
        private void Speed(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Speed), new object[] { value });
                return;
            }
            labelSpeed.Text = value;
        }
