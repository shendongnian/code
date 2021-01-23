    public void PingTest(object sender, EventArgs e)
    {
        Ping pingClass = new Ping();
        PingReply pingReply = pingClass.Send("google.com");
        rtxtPing.Text = rtxtPing.Text + "\r\n" + (pingReply.RoundtripTime.ToString() + "ms");        
    }
