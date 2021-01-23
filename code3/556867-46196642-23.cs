    public void UpdatePing()
    {     
        try
        {
            Ping myPing = new Ping();
            PingReply reply = myPing.Send(textBox1.Text, 1000);
            if (reply != null)
            {
                label17.Text = reply.Status.ToString();
                label18.Text = reply.RoundtripTime.ToString();                    
            }
        }
        catch
        {
            label17.Text = "ERROR: You have Some TIMEOUT issue";
            label18.Text = "ERROR: You have Some TIMEOUT issue";                
        }
    }
