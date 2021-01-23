    public void SetModem()
        {
    
            if (port.IsOpen == false)
            {
                port.Open();
            }
    
            port.WriteLine(sData + System.Environment.NewLine);
            port.BaudRate = iBaudRate;
            port.DtrEnable = true;
            port.RtsEnable = true;
      
            port.DataReceived += port_DataReceived;
    
        }
        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
                //For e.g. display your incoming data in RichTextBox
                richTextBox1.Text += this.serialPort1.ReadLine();           
               //OR
               ReadModem();
        }
