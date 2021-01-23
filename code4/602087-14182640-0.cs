        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            label1.Visible = true;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); //If timer is not stopped, timer1_Tick event will be called for every 10 seconds
            label1.Visible = false;
        }
