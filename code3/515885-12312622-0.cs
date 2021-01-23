        public class PrintToZebra
        {
            public string printerIP { get; set; }
            public int printerPort { get; set; }
            public string myZPL { get; set; }
            private EndPoint ep { get; set; }
            private Socket sock { get; set; }
            private NetworkStream ns { get; set; }
            //private AsyncCallback callbackWrite;
        public PrintToZebra()
        {
            printerIP = "";
            printerPort = 0;
            myZPL = "";
        }
        public PrintToZebra(string anIP, int aPort, string aZPL)
        {
            printerIP = anIP;
            printerPort = aPort;
            myZPL = aZPL;
        }
        public void printToIP()
        {
            ep = new IPEndPoint(IPAddress.Parse(printerIP), printerPort);
            sock = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sock.Connect(ep);
                ns = new NetworkStream(sock);
                byte[] toSend = Encoding.ASCII.GetBytes(myZPL);
                ns.BeginWrite(toSend, 0, toSend.Length, OnWriteComplete, null);
                ns.Flush(); 
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }
        private void OnWriteComplete(IAsyncResult ar)
        {
            NetworkStream thisNS = ns;
            thisNS.EndWrite(ar);
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();
        }
    }
