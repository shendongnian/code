    private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string inData = serialPort1.ReadLine(); // ReadLine includes the "+ \n"
        displayToWindow(inData);
    }
    
    private void displayToWindow(string inData)
    {
        BeginInvoke(new EventHandler(delegate
        {
            richTextBox1.AppendText(inData);
            richTextBox1.ScrollToCaret();
        }));
    }
