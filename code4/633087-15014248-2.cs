    public static bool connect(string comPort, Form1 whichForm) {
        BTserial = new SerialPort(comPort, 9600, Parity.None, 8, StopBits.One);
        BTserial.Open();
        if (BTserial.IsOpen) {
            BTserial.DataReceived += (sender, e) {
              Debug.WriteLine("Data Incomming!");
              // Check if Chars are received
              if (e.EventType == SerialData.Chars) {
                  Debug.WriteLine("Chars!");
                  // Create new buffer
                  byte[] ReadBuffer = new byte[BTserial.BytesToRead];
  
                  // Read bytes from buffer
                  BTserial.Read(ReadBuffer, 0, ReadBuffer.Length);
                  BTserial.DiscardInBuffer();
                  // Encode to string
                  string data = bytesToString(ReadBuffer);
                
                  Action toBeRunOnGuiThread = () => whichForm.theTextBox.Text = data;
                  // to guard yourself from all evil
                  // you could check to see if it is needed to
                  if (whichForm.InvokeRequired) 
                    // marshal the call to the action all the way to the GUI thread
                    whichForm.Invoke(toBeRunOnGuiThread);
                  else
                    // or, if we ARE on the GUI thread already, just call it from this thread
                    toBeRunOnGuiThread();
                  ReadBuffer = null;
                  data = null;
              }
        };
            return true;
        } else {
            return false;
        }
    }
