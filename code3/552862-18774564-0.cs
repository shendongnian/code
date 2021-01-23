    void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        var com = sender as SerialPort;
        var lst = new List<byte>();
        if (com != null)
        {
            lock (com)
            {
                do
                {
                    if (com.BytesToRead == 0) break;
                    var one = com.ReadByte();
                    if (one >= 0 && one < 256) lst.Add(Convert.ToByte(one));
                } while (one >= 0 && one < 256);
                
                // lst.ToArray(); // get bytes
            }
            // ... // do something with received data
        }
    }
