    public Load()
    {
        InitializeComponent();
    
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Interval = 1000;
    
        // I can't transfer parameters here
        timer.Elapsed += new ElapsedEventHandler(timer_Elapsed); 
        timer.Start();
    }
     private delegate void ChangeLabel();
            private void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                var ChangeLabel = new ChangeLabel(ChangeText);
                this.BeginInvoke(ChangeLabel);
                
            }
            private void ChangeText()
            {
                label1.Text = label1.Text + ".";
            }
