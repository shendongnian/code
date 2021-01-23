        private Thread _udpReadThread;
        private volatile bool _terminateThread;
        public event DataEventHandler OnDataReceived;
        public delegate void DataEventHandler(object sender, DataEventArgs e);
        private void CreateUdpReadThread()
        {
            _udpReadThread = new Thread(UdpReadThread) { Name = "UDP Read thread" };
            _udpReadThread.Start(new IPEndPoint(IPAddress.Any, 1234));
        }
        private void UdpReadThread(object endPoint)
        {
            var myEndPoint = (EndPoint)endPoint;
            var udpListener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpListener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            
            // Important to specify a timeout value, otherwise the socket ReceiveFrom() 
            // will block indefinitely if no packets are received and the thread will never terminate
            udpListener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 100);
            udpListener.Bind(myEndPoint);
            try
            {
                while (!_terminateThread)
                {
                    try
                    {
                        var buffer = new byte[1024];
                        var size = udpListener.ReceiveFrom(buffer, ref myEndPoint);
                        Array.Resize(ref buffer, size);
                        // Let any consumer(s) handle the data via an event
                        FireOnDataReceived(((IPEndPoint)(myEndPoint)).Address, buffer);
                    }
                    catch (SocketException socketException)
                    {
                        // Handle socket errors
                    }
                }
            }
            finally
            {
                // Close Socket
                udpListener.Shutdown(SocketShutdown.Both);
                udpListener.Close();
            }
        }
        public class DataEventArgs : EventArgs
        {
            public byte[] Data { get; private set; }
            public IPAddress IpAddress { get; private set; }
            public DataEventArgs(IPAddress ipaddress, byte[] data)
            {
                IpAddress = ipaddress;
                Data = data;
            }
        }
