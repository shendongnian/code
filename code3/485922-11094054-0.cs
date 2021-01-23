    private string receiver;
    
    public System.Timers.Timer timer = new System.Timers.Timer(200);
    private void btnAutoSend_Click(object sender, EventArgs e)
    {
        timer.Enabled = true;
        receiver = 'your val';
        timer.Elapsed += new System.Timers.ElapsedEventHandler(send);
        timer.AutoReset = true;
    }
    
    public void send(object source, System.Timers.ElapsedEventArgs e)
    {
        this.rtbMsg.AppendText("psyche-->" + receiver + ": hello\n");
    }
