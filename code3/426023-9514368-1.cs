        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (SyncObject)
            {
                if (!_serialPort.IsOpen) return;
                try
                {                    
                    int toread = _serialPort.BytesToRead;
                    byte[] bytes = new byte[toread];
                    _serialPort.Read(bytes, 0, toread);
                   ProducerAddBytes(bytes);
                }
                catch (TimeOutException)
                {
                    //logic
                }
            }
        }
    
