    public class ConnectionStateUSB
        {
            internal Socket _conn;
            //internal TcpServiceProvider _provider;
            internal byte[] _buffer;
    
            /// <SUMMARY>
            /// Tells you the IP Address of the remote host.
            /// </SUMMARY>
            public EndPoint RemoteEndPoint
            {
                get { return _conn.RemoteEndPoint; }
            }
    
            /// <SUMMARY>
            /// Returns the number of bytes waiting to be read.
            /// </SUMMARY>
            public int AvailableData
            {
                get { return _conn.Available; }
            }
    
            /// <SUMMARY>
            /// Tells you if the socket is connected.
            /// </SUMMARY>
            public bool Connected
            {
                get { return _conn.Connected; }
            }
    
            /// <SUMMARY>
            /// Reads data on the socket, returns the number of bytes read.
            /// </SUMMARY>
            public int Read(byte[] buffer, int offset, int count)
            {
                try
                {
                    if (_conn.Available > 0)
                        return _conn.Receive(buffer, offset, count, SocketFlags.None);
                    else return 0;
                }
                catch
                {
                    return 0;
                }
            }
    
            /// <SUMMARY>
            /// Sends Data to the remote host.
            /// </SUMMARY>
            public bool Write(byte[] buffer, int offset, int count)
            {
                try
                {
                    _conn.Send(buffer, offset, count, SocketFlags.None);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
    
    
            /// <SUMMARY>
            /// Ends connection with the remote host.
            /// </SUMMARY>
            public void EndConnection()
            {
                if (_conn != null && _conn.Connected)
                {
                    _conn.Shutdown(SocketShutdown.Both);
                    _conn.Close();
                }
            }
        }
    
        class USBSerialPort
        {
            Socket newsock;
            Socket client;
            int port;
            IPAddress ipaddress;
            private AsyncCallback ConnectionReady;
            private AsyncCallback AcceptConnection;
            private AsyncCallback ReceivedDataReady;
            private ConnectionStateUSB currentST;
            public bool IsConnected = false;
    
            public USBSerialPort(int _port)
            {
                port = _port;
                //ConnectionReady = new AsyncCallback(ConnectionReady_Handler);
                //AcceptConnection = new AsyncCallback(AcceptConnection_Handler);
                //ReceivedDataReady = new AsyncCallback(ReceivedDataReady_Handler);
            }
    
            public void Start()
            {            
                try
                {
                    ipaddress = Dns.GetHostEntry("ppp_peer").AddressList[0];
                    newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint iep = new IPEndPoint(ipaddress, port);
                    newsock.BeginConnect(iep, new AsyncCallback(Connected), newsock);
                }
                catch (Exception ex)
                {
                    throw ex;
                    this.Stop();
                }
                finally
                {
                    //net_stream = null;
                    //tcp_client = null;
                }
            }
    
            void Connected(IAsyncResult iar)
            {            
                try
                {
                    client = (Socket)iar.AsyncState;
                    client.EndConnect(iar);
    
                    ConnectionStateUSB st = new ConnectionStateUSB();
                    st._conn = client;
                    st._buffer = new byte[4];
                    //Queue the rest of the job to be executed latter
                    //ThreadPool.QueueUserWorkItem(AcceptConnection, st);
                    currentST = st;
                    //conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();
                    if (client.Connected)
                        client.BeginReceive(st._buffer, 0, 0, SocketFlags.None,
                                      new AsyncCallback(ReceiveData), st);                
                }
                catch (SocketException e)
                {
                    IsConnected = false;
                    //conStatus.Text = "Error connecting";
                }
                catch (Exception ex)
                {
                    IsConnected = false;
                }
            }
    
            void ReceiveData(IAsyncResult iar)
            {
                try
                {
                    ConnectionStateUSB remote = (ConnectionStateUSB)iar.AsyncState;
                    remote._conn.EndReceive(iar);
                    try
                    {                    
                        this.OnReceiveData(remote);
                        IsConnected = true;
                    }
                    catch (Exception ex)
                    {
                        IsConnected = false;
                    }
                    //int recv = remote.EndReceive(iar);
                    //string stringData = Encoding.ASCII.GetString(data, 0, recv);
                    //results.Items.Add(stringData);
                    if (remote.Connected)
                        remote._conn.BeginReceive(remote._buffer, 0, 0, SocketFlags.None,
                                      new AsyncCallback(ReceiveData), remote);
                }
                catch (Exception ex)
                {
                    this.Stop();
                }
            }
    
            public void SendData(byte[] data)
            {
                try
                {
                    bool a = currentST.Write(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    IsConnected = false;
                    MessageBox.Show("Error!\n" + ex.Message + "\n" + ex.StackTrace);
                }
            }
    
            public void SendData(string data)
            {
                try
                {
                    byte[] msg = Encoding.UTF8.GetBytes(data + Convert.ToChar(Convert.ToByte(3)));
                    bool a = currentST.Write(msg, 0, msg.Length);
                    msg = null;
                }
                catch (Exception ex)
                {
                    IsConnected = false;
                    MessageBox.Show("Error!\n" + ex.Message + "\n" + ex.StackTrace);
                }
            }
    
    
            /// <SUMMARY>
            /// Shutsdown the server
            /// </SUMMARY>
            public void Stop()
            {
                //lock (this)
                //{
                    if (newsock != null)
                        newsock.Close();
                    if (client != null)
                        client.Close();
                    if (currentST != null)
                    {
                        currentST._conn.Close();
                        currentST = null;
                    }
                    IsConnected = false;
                //}
            }
    
            /// <SUMMARY>
            /// Gets executed when the server accepts a new connection.
            /// </SUMMARY>
            public delegate void EventOnAcceptConnection(ConnectionStateUSB socket);
            public event EventOnAcceptConnection OnAcceptConnection;
    
            /// <SUMMARY>
            /// Gets executed when the server detects incoming data.
            /// This method is called only if OnAcceptConnection has already finished.
            /// </SUMMARY>
            public delegate void EventOnReceiveData(ConnectionStateUSB socket);
            public event EventOnReceiveData OnReceiveData;
    
            /// <SUMMARY>
            /// Gets executed when the server needs to shutdown the connection.
            /// </SUMMARY>
            public delegate void EventOnDropConnection(ConnectionStateUSB socket);
            public event EventOnDropConnection OnDropConnection;
        }
