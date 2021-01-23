        private void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Tick += new EventHandler(timer_dosomething);
            timer1.Interval = 60000;
            timer1.Enabled = true;
            timer1.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        void timer_dosomething(object sender, EventArgs e)
        {
            Console.Beep();
        }
