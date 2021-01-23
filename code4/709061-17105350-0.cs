        private void Scan_Screen(object sender, EventArgs e)
        {
            textBox1.Text += "a";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            g_RECEIVER_timer = new System.Windows.Forms.Timer();
            g_RECEIVER_timer.Enabled = true;
            g_RECEIVER_timer.Interval = 1000;
            g_RECEIVER_timer.Tick += new EventHandler(Scan_Screen);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Thread g_Control_Thread = new Thread(new ParameterizedThreadStart(Control_Message_Receiver));
            g_Control_Thread.Start(1);
        }
        //thread function
        public void Control_Message_Receiver(object v)
        {
            //timer1.Stop(); //why stop? -- remove this instead
            IntervalChange((int)v); //call this method and invoke it on the UI thread
            g_RECEIVER_timer.Enabled = true;
            //timer1.Tick += new EventHandler(Scan_Screen); // -- remove this
        }
        delegate void intervalChanger(int time);
        void ChangeInterval(int time)
        {
            g_RECEIVER_timer.Interval = time;
        }
        void IntervalChange(int time)
        {
            this.Invoke(new intervalChanger(ChangeInterval), new object[] {time}); //invoke on the UI thread
        }
