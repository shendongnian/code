     System.Net.Sockets.Socket sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                    sock.Connect(url, proxyPort);
                    if (sock.Connected == true)  // Port is in use and connection is successful
                    {
                        sock.Close();
                        return true;
                    }
                    else
                    {
                        sock.Close();
                    }`enter code here`
                    return false;
