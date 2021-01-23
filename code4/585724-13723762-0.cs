    var serialPort1 = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
    serialPort1.Encodeing = System.Text.Encoding.Default;
    serialPort1.Open();
    serialPort1.Write(2);
    serialPort1.Write(textbox1.Text.Trim());
    serialPort1.Close();
