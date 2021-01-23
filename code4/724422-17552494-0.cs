    void OpenConnection()
    {
        //Create new serialport
        _serialPort = new SerialPort("COM8");
    
        //Make sure we are notified if data is send back to use
        _serialPort.DataReceived += _serialPort_DataReceived;
    
        //Open the port
        _serialPort.Open();
    
        //Write to the port
        _serialPort.Write("UUT_SEND \"REMS\\n\" \n");
    }
    
    void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        //Read all existing bytes
        var received = _serialPort.ReadExisting();
    }
    
    void CloseConnectionOrExitAppliction()
    {
        //Close the port when we are done
        _serialPort.Close();
    }
