                ///<summary>
                ///creating new serialPort, fill it with a portname and give it BaudRate value 9600.
                ///</summary>
                _serialPort = new SerialPort();
                _serialPort.PortName = portname;
                _serialPort.BaudRate = 9600;
                _serialPort.Parity = Parity.None;
                _serialPort.StopBits = StopBits.One;
    
                try
                {
                    if (!_serialPort.IsOpen)
                    {
                        //open the port.
                        _serialPort.Open();
                    }
                    //when the port is open
                    if (_serialPort.IsOpen)
                    {          
                        _serialUsbThread = new Thread(SerialWorker);
                        _serialUsbThread.Priority = ThreadPriority.Highest;
                        _serialUsbThread.Start();
                    }   
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(DateTime.UtcNow + " SERIAL: " + ex.Message);
                }         
  
