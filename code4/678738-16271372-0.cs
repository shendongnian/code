    class SerialPortProgram
        {
            // Create the serial port
            private SerialPort port;
            MainWindow _window;
            private Dispatcher _dispatcher;
    
            public SerialPortProgram(MainWindow window)
            {
                _window = window;
                AppendText("Incoming Data:");
                port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
                // Attach a method to be called when there
                // is data waiting in the port's buffer
                port.DataReceived += port_DataReceived;
                _dispatcher = Dispatcher.CurrentDispatcher;
                // Begin communications
                port.Open();
    
            }
    
    
    
            private void AppendText(string text)
            {
                _dispatcher.Invoke(() => {
                   _window.Dev_output.Text += string.Format("{0}{1}", text, Environment.NewLine);
                });
            }
    
            private void port_DataReceived(object sender,
              SerialDataReceivedEventArgs e)
            {
                // Show all the incoming data in the port's buffer
                AppendText(port.ReadExisting());
            }
        }
