        int tik = 0;
        TimeSpan examTime;
        public MarksExamStart(string MarksSelected,string DurationID)
        {
            InitializeComponent();
            examTime = TimeSpan.FromMinutes(conf[3]); // If that's not double you'll need to parse it and make sure it's in the right format
            label1.Text = conf[2];//showing 30/1/2 in label1
            label2.Text = conf[3];//showing min/hr in label2                
            timer1.Interval = 60 * 1000;
            timer1.Start();
        } 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sender == timer1)
            {
                examTime = examTime.Subtract(TimeSpan.FromMinutes(1));
                label1.Text = examTime.ToString();
            }
        }  
