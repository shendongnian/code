    private void StartPollingMessage()
    {
        System.Windows.Forms.Timer myTimer = new Timer();
        myTimer.Tick += new EventHandler(myTimer_Tick);
        myTimer.Interval = 200;
        myTimer.Start();
    }
    
    void myTimer_Tick(object sender, EventArgs e)
    {
        textBox1.Text = myobj.messages;
    }
