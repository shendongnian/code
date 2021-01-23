    public void comboBox_DropDownOpened(object sender, EventArgs e)
        {   
            string[] ports = SerialPort.GetPortNames();          
            foreach ( string comport in ports)
                {
                    comboBox.Items.Add(comport);
                }
        }
    .... /*Two control item combobox&button, comboxbox's item is COM port and   It's first argument of Function 「System.IO.Ports.SerialPort 」. Using (comboBox.text) */
    private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            System.IO.Ports.SerialPort Port = new SerialPort
                ((comboBox.Text), 115200, Parity.None, 8, StopBits.One);
            try
            {
                Port.Open();
                Port.Write(cmdByteArray, 0, cmdByteArray.Length );
            }
            catch { Exception ex; }
            Port.Read(readbyte, 0, readbyte.Length);
