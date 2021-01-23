    public void SendDataOverSerial(string data) {
      try {
         SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One); 
         port.Open(); 
         port.Write(data); 
      }
      finally {
         port.Close();    
      }
    }
