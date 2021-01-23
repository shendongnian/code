    private void serialPort1_DataReceived(object sender,  System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        // get number off bytes in buffer 
        int n = serialPort1.BytesToRead;
        byte[] buffer = new byte[n];
        // read one byte from buffer 
        int bytesToProcess = serialPort1.Read(buffer, 0, n);                     
        this.Invoke(UpdateMethod, buffer, bytesToProcess);            
    }
