    public class SerialPortController
    {
        private ImageViewModel ivm;
        public SerialPortController(ImageViewModel ivm)
        {
            this.ivm = ivm;
        }
        public void OpenPort()
        {
            ...
        }
        public void ClosePort()
        {
            ...
        }
        private void receivedDataFromSerialPort(object sender, SerialDataReceivedEventArgs e)
        {
            ...
        }
    }
