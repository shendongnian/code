    class Something
    {
        DateTime _myDateTime;
        Timer _timer;
        public Something()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _myDateTime = DateTime.Now;
            _timer.Start();
            
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            var diff = DateTime.Now.Subtract(_myDateTime);
            this.textBox1.Text = diff.ToString();
        }
    }
