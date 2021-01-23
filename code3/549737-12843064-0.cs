    private void DataReceivedHandler(object sender,System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        String s=sp.ReadExisting();
        while(s != ".")
        {
            myReceivedLines += s;
            String s=sp.ReadExisting();
        }
    }
