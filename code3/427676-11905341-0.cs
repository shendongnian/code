    using System.Net;
    using System.Net.Sockets;
    
    static Socket sck;
    
     acceptClient(String str)
            {
                sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 777);
                try
                {
                    sck.Connect(localEndPoint);
                    string text = str;
                    byte[] data = Encoding.ASCII.GetBytes(text);
    
                    sck.Send(data);
                   // MessageBox.Show("Data Sent!\r\n");
                }
                catch
                {
                    MessageBox.Show("Unable to connect to remote end point!\r\n");
                }
                
            }
    
    
