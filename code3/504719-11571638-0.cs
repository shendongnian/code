    private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        if (!this.Open) return; // We can't receive data if the port has already been closed.  This prevents IO Errors from being half way through receiving data when the port is closed.
        string line = String.empty;
        try
        {
            line = _SerialPort.ReadLine();
            line = line.Trim();
           //process your data if it is "DATA C", otherwise ignore
        }
        catch (IOException ex)
        {
            //process any errors
        }
    }
