    public void OnSerialDataRecevied(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        var bytes = new UTF8Encoding().GetBytes(sp.ReadExisting());
        if(DataReceivedHandler != null)
            DataReceivedHandler(sender, e);
    }
