        public void initConfig(SerialPort serialPort)
        {
            // you can assign these values in a combo box
            string[] ports= "{COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8"};
            //you can assign these values in a combo box in a string format
            int[] baudRate = { 4800, 9600, 19200, 38400, 57600, 115200, 230400 };
            serialPort.PortName = ports[0]; //else get from combobox  : portCombobox.SelectedItem
            serialPort.BaudRate = baudRate[0];
            //serialPort.BaudRate = Int32.Parse(speedComboBox.SelectedItem.ToString());
            //you can have controls to store and change these values if required
            serialPort.Handshake = System.IO.Ports.Handshake.None;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = System.IO.Ports.StopBits.One;
            serialPort.ReadTimeout = 200;
            serialPort.WriteTimeout = 50;
        }
