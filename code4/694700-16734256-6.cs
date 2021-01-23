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
        }
    }
         
