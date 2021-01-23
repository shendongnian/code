        private void SerialPortReadCallback(object sender, SerialDataReceivedEventArgs args)
        {
            try
            {
                while (serialPort1.BytesToRead > 0)
                {
                    // Do something with the data
                       
                }
            }
            catch (Exception ex)
            {
            }
        }
