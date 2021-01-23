    public class Conex {
      string NewLine = "\r";
      int BaudRate = 921600, DataBits = 8, ReadTimeout = 100, WriteTimeout = 100;
      Parity Parity = Parity.None;
      StopBits StopBits = StopBits.One;
      SerialPort Serial;
      public Conex(string PortName) {
        Serial = new SerialPort(PortName, BaudRate, Parity, DataBits, StopBits);
        Serial.ReadTimeout = ReadTimeout;
        Serial.WriteTimeout = WriteTimeout;
        Serial.NewLine = NewLine;
      }
      public void Open() {
        Serial.Open();
      }
      public void Close() {
        Serial.Close();
      }
    }
