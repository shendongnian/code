    public class SerialIO : IDataIO
    {
        private SerialPort _port;
        
        public IObservable<byte[]> DataRecived
        {
            get
            {
                return Observable.FromEventPattern<SerialDataReceivedEventHandler,
                                                   SerialDataReceivedEventArgs>(
                            h => _port.DataReceived += h,
                            h => _port.DataReceived -= h)
                       .Where(ep => ep.EventArgs.EventType == SerialData.Chars)
                       .Select(ep =>
                               {
                                  byte[] buffer = new byte[_port.BytesToRead];
                                  _port.Read(buffer, 0, buffer.Length);
                                  return buffer;
                               });
            }
        }
    }
