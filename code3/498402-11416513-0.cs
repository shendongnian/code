    public delegate void RawDataEventHandler(object sender, RawDataEventArgs e);
    public event RawDataEventHandler RawDataReceived;
    void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string ReceivedData = _serialPort.ReadExisting();
        if (RawDataReceived != null)
            RawDataReceived(this, new RawDataEventArgs(ReceivedData));
    }
    class RawDataEventArgs : EventArgs
    {
        public string Data { private set; get; }
        public RawDataEventArgs(string data)
        {
            Data = data;
        }
    }
