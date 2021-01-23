    private System.Windows.Forms.Timer mCloseAppTimer;
    private void ExitButton_Click(object sender, EventArgs e) 
    { 
        notifyIcon.Visible = false; notifyIcon.Dispose; 
        mCloseAppTimer = new System.Windows.Forms.Timer(); 
        mCloseAppTimer.Interval = 100; 
        mCloseAppTimer.Tick += new EventHandler(OnCloseAppTimerTick); 
    } 
    private void OnCloseAppTimerTick(object sender, EventArgs e) 
    { 
        Environment.Exit(0); // other exit codes are also possible 
    }
