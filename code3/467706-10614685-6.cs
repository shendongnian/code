            private void button1_Click(object sender, EventArgs e)
        {
            _serialPort = new SerialPort(comboBox1.Text, BaudRate, Parity.None, 8, StopBits.One);
            _serialPort.DataReceived += SerialPortOnDataReceived;
            _serialPort.Open();
        }
        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            while(_serialPort.BytesToRead >0)
            {
                textBox1.Text += string.Format("{0:X2} ", _serialPort.ReadByte());
            }
        }
