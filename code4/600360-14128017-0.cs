    public void OnReceived(object sender, SerialDataReceivedEventArgs c) // This is started in another thread...
    {
        com.DiscardOutBuffer();
        try
        {
            test = com.ReadExisting();
            SetValue(test);       
        }
        catch (Exception exc) 
        {
            SetValue(exc.ToString());
        }
    }
    delegate void valueDelegate(string value);
    private void SetValue(string value)
    {   
        if (this.InvokeRequired)
        {
            this.Invoke(new valueDelegate(SetValue),value);
        }
        else
        {
            MessageBox.Show(value);
        }
    }
