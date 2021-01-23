    private void Form1_Load(object sender, EventArgs e)
    {
        timer1 = new System.Windows.Forms.Timer();
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Interval = 1000; // 1 second
    
        InterceptKeys.InterceptInit();
        InterceptKeys.HomePressed += ()=> StartTimer();
        InterceptKeys.EndPressed += ()=> StopTimer();
    }
