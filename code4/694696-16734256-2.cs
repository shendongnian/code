    private void ResetConnection()
    {
        try
        {
            //Send any data to cause an IOException
            serialPort.Write("Any value");
        }
        catch (IOException ex)
        {
            //Dispose the SafeSerialPort
            serialPort.Dispose();
            serialPort.Close();
            //Reset the port: this code = Disable/Enable in the device manager
            Task.Factory.StartNew(() =>
            {
                PortHelper.TryResetPortByName("COM8");
            });
        }
    }
         
