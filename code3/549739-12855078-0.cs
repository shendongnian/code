    //Fields
    List<string> myReceivedLines;
    //subscriber method for the port.DataReceived Event
    private void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        while(sp.BytesToRead > 0)
        {
            try 
            {
                myReceivedLines.Add(sp.ReadLine());
            }
            catch(TimeOutException) 
            {
                break;
            }
        }
    }
