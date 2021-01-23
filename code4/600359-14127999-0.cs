    public void OnReceived(object sender, SerialDataReceivedEventArgs c)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new EventHandler<SerialDataReceivedEventArgs>(OnReceived), sender, c);
            return;
        }
        com.DiscardOutBuffer();
        try
        {
            test = com.ReadExisting();
            MessageBox.Show(test);       
        }
        catch (Exception exc) 
        {
            MessageBox.Show(exc.ToString());
        }
    }
