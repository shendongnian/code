    private void Form1_Load()
    {
          Timer tmr = new Timer();
          tmr.Interval = 1000;//updates every 1 second
          tmr.Tick+=new EventHandler(t1_Tick);
          tmr.Start();    
    }
    //change the label text inside the tick event
    private void tmr_Tick(object sender, EventArgs e)
    {
          LblLocalTime.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
          LblUTCTime.Text   = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");          
    }
