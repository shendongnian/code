    public delegate void GetData(string receivedData);
    void mySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            if (RFIDActive)
            {
                SerialPort sp = (SerialPort)sender;
                RFIDSerial = sp.ReadLine();
                this.Invoke(new GetData(ShowID),RFIDSerial);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
