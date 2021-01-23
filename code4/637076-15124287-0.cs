    class DataCollector
    {
        private readonly Action<List<byte>> _processMeasurement;
        private readonly string _port;
        private SerialPort _serialPort;
        private const int SizeOfMeasurement = 4;
        List<byte> Data = new List<byte>();
    
        public DataCollector(string port, Action<List<byte>> processMeasurement)
        {
            _processMeasurement = processMeasurement;
            _serialPort = new SerialPort(port);
            _serialPort.DataReceived +=SerialPortDataReceived;
        }
    
        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while(_serialPort.BytesToRead > 0)
            {
               var count = _serialPort.BytesToRead;
               var bytes = new byte[count];
               _serialPort.Read(bytes, 0, count);
               AddBytes(bytes);
            }
        }
    
        private void AddBytes(byte[] bytes)
        {
            Data.AddRange(bytes);
            while(Data.Count > SizeOfMeasurement)            
            {
                var measurementData = Data.GetRange(0, SizeOfMeasurement);
                Data.RemoveRange(0, SizeOfMeasurement);
                if (_processMeasurement != null) _processMeasurement(measurementData);
            }
            
        }
    }
