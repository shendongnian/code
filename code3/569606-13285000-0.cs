    public class DataSender
        {
            public DataSender(string ip, int port)
            {
                IP = ip;
                Port = port;
            }
            private string IP;
            private int Port;
            System.Threading.Thread sender;
            private bool issending = false;
            public void StartSending()
            {
                if (issending)
                {
                    // it is already started sending. throw an exception or do something.
                }
                issending = true;
                sender = new System.Threading.Thread(SendData);
                sender.IsBackground = true;
                sender.Start();
            }
            public void StopSending()
            {
                issending = false;
                if (sender.Join(200) == false)
                {
                    sender.Abort();
                }
                sender = null;
            }
            private void SendData()
            {
                System.Net.Sockets.UdpClient _sockMain = new System.Net.Sockets.UdpClient(IP, Port);
                while (issending)
                {
                    // Define and assign arr_bData somewhere in class
                    _sockMain.Send(arr_bData, arr_bData.Length);
                }
            }
        }
