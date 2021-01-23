    static int checkOld = 0;
    static int checkNew = 0;
    
    private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
    
        checkNew++;
    
        string someVariable = serialPort.ReadLine();
        labelStatus.Invoke((MethodInvoker)(() => labelStatus.Text = "Connected"));
        //If i received something that means the device is plugged in and connection is correct (still very simplified)
    }
    
    private void timer_Tick(object sender, EventArgs e)
    {
        if (serialPort.IsOpen)
        {
            serialPort.WriteLine("r"); //I'm sending "r" message and device send data back
        }
        if (checkOld == checkNew)
        {
            labelStatus.Invoke((MethodInvoker)(() => labelStatus.Text = "Not connected"));
        }
    }
