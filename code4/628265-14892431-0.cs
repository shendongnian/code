        private static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // prevent error with closed port to appears
            if (!_port.IsOpen)
                return;
            // read data
            if (_port.BytesToRead >= 1)
            {
                // ...
                // read data into a buffer _port.ReadByte()
                DataReceived(sender, e);
            }
            // ...
            // if buffer contains data, process them
        }
