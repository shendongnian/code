        public int percentage;
        public int Percentage
        {
            get { return percentage; }
            set
            {
                percentage = value;
                if (Percentage >= 0 && Percentage < 100)
                {
                    progressBar1.Value = value;
                }
                else
                {
                    Percentage = 0;
                    timer1.Stop();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Percentage = 0;
            timer1.Interval = 1000;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            double addValue = 100 / 3;
            Percentage += (int)addValue;
        }
