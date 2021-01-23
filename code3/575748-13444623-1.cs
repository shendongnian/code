    SerialPort serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
    
    var esc = new byte { 27 };
    var c = new byte { 99 };
    
    serialPort.Write(esc, 0, 1);
    
    serialPort.ReadTo(">"); // Or ReadByte() and check if the byte read has a value of 62
    
    serialPort.Write(c, 0, 1);
    
    string data = serialPort.ReadTo("<");
