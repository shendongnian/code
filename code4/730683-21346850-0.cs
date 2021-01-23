    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using System.Net;
    using System.Net.Sockets;
    using Org.Mentalis.Network.ProxySocket;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        /*
         * HTTPS is not supported, it will probably result in a (400) 'Bad Request' response. 
         */
    
        public class HttpOverSocksProxy
        {
            private class Connection
            {
                public IPLocation host_loc;
                public bool host_found = false;
                public bool host_connected = false; //if have_found==true && host_connected==false then we are currently connecting to the host
                public long host_last_read_pos = 0;
    
                public NetworkStream client_stream = null;
                public TcpClient client_tcp = null;
    
                public NetworkStream host_stream = null;
                public ProxySocket host_socket = null;
    
                public byte[] client_buf_ary = null;
                public byte[] host_buf_ary = null;
                public MemoryStream buf_str = null;
    
                public Connection(NetworkStream str,TcpClient client,int buffer_size)
                {
                    this.client_stream = str;
                    this.client_tcp = client;
                    this.host_buf_ary = new byte[buffer_size];
                    this.client_buf_ary = new byte[buffer_size];
                    this.buf_str = new MemoryStream(buffer_size);
                }
            }
    
            private struct IPLocation
            {
                public string host;
                public int port;
    
                public IPLocation(string host, int port)
                {
                    this.host = host;
                    this.port = port;
                }
            }
    
            private TcpListener _tcp_server;
            private List<Connection> _connections = new List<Connection>();
    
            public IPEndPoint EndPoint_Source_Http { get; private set; }
            public IPEndPoint EndPoint_Destination_Socks { get; private set; }
            public ProxyTypes SocksProxyType { get; private set; }
            public int Buffer_Size { get; private set; }
    
            public HttpOverSocksProxy(IPEndPoint http_listen, IPEndPoint socks_proxy, ProxyTypes socks_proxy_type, int buffer_size = 1024*4)
            {
                this.EndPoint_Source_Http = http_listen;
                this.EndPoint_Destination_Socks = socks_proxy;
                this.SocksProxyType = socks_proxy_type;
                this.Buffer_Size = buffer_size;
            }
    
            public void Start()
            {
                _tcp_server = new TcpListener(EndPoint_Source_Http);
                _tcp_server.Start();
                _tcp_server.BeginAcceptTcpClient(Client_Accept, _tcp_server);
            }
    
            public void Stop()
            {
                lock (_connections)
                {
                    _tcp_server.Stop();
                    _connections.ForEach(a => Close(a));
                    _connections.Clear();
                }
            }
    
            private void Client_Accept(IAsyncResult result)
            {
                TcpListener tcp_server = result.AsyncState as TcpListener;
    
                if (tcp_server != null)
                {
                    TcpClient tcp_client = tcp_server.EndAcceptTcpClient(result);
    
                    if (tcp_client != null)
                    {
                        Connection conn = new Connection(tcp_client.GetStream(), tcp_client, Buffer_Size);
    
                        lock (_connections)
                        {
                            _connections.Add(conn);
                        }
    
                        conn.client_stream.BeginRead(conn.client_buf_ary, 0, Buffer_Size, Client_Write, conn);
                    }
    
                    tcp_server.BeginAcceptTcpClient(Client_Accept, tcp_server);
                }
            }
    
            private void Client_Write(IAsyncResult result)
            {
                Connection conn = result.AsyncState as Connection;
    
                if (conn != null)
                {
                    try
                    {
                        int len = conn.client_stream.EndRead(result);
    
                        if (len == 0) // Client has closed the connection
                        {
                            Close(conn);
                        }
                        else
                        {
                            lock (conn)
                            {
                                if (conn.host_connected)
                                {
                                    try
                                    {
                                        conn.host_stream.Write(conn.client_buf_ary, 0, len); //we want this to block
                                    }
                                    catch (Exception e_h)
                                    {
                                        if (!Handle_Disposed(e_h, conn))
                                            throw;
                                    }
                                }
                                else
                                    conn.buf_str.Write(conn.client_buf_ary, 0, len);
    
                                if (!conn.host_found)
                                    OpenHostConnection(conn);
    
                                conn.client_stream.BeginRead(conn.client_buf_ary, 0, Buffer_Size, Client_Write, conn);
                            }
                        }
                    }
                    catch (Exception e_c)
                    {
                        if (!Handle_Disposed(e_c, conn))
                            throw;
                    }
                }
            }
    
            private void OpenHostConnection(Connection conn)
            {
                if (conn.host_found)
                    throw new Exception("Already have host");   //should never happen
    
                #region Get Host from headers
                {
                    MemoryStream str_mem = conn.buf_str;
                    str_mem.Position = conn.host_last_read_pos;
    
                    string raw_host_line;
                    while ((raw_host_line = ReadLine(str_mem, ASCIIEncoding.ASCII)) != null)
                    {
                        conn.host_last_read_pos = str_mem.Position;
    
                        if (raw_host_line.Length == 0)
                            throw new Exception("Failed to find Host in request headers");
    
                        int idx_split;
                        if ((idx_split = raw_host_line.IndexOf(':')) > 0 && idx_split < raw_host_line.Length)
                        {
                            string key = raw_host_line.Substring(0, idx_split);
                            string val = raw_host_line.Substring(idx_split + 1).Trim();
    
                            if (key.Equals("host", StringComparison.InvariantCultureIgnoreCase))
                            {
                                string[] host_parts = val.Split(':');
    
                                if (host_parts.Length == 1)
                                {
                                    conn.host_loc = new IPLocation(host_parts[0], 80);
                                }
                                else if (host_parts.Length == 2)
                                {
                                    conn.host_loc = new IPLocation(host_parts[0], Int32.Parse(host_parts[1]));
                                }
                                else
                                    throw new Exception(String.Format("Failed to parse HOST from '{0}'", raw_host_line));
    
                                conn.host_found = true;
                            }
                        }
                    }
    
                    str_mem.Seek(0,SeekOrigin.End);
                }
                #endregion
    
                #region Open Host Connection
                {
                    if (conn.host_found)
                    {
                        try
                        {
                            ProxySocket skt = new ProxySocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            skt.ProxyEndPoint = EndPoint_Destination_Socks;
                            skt.ProxyType = ProxyTypes.Socks5;
                            conn.host_socket = skt;
    
                            if (conn.host_loc.port == 443)
                                Console.WriteLine("HTTPS is not suported.");
    
                            skt.BeginConnect(conn.host_loc.host, conn.host_loc.port, Host_Connected, conn);
                        }
                        catch (ObjectDisposedException e)
                        {
                            if (!Handle_Disposed(e, conn))
                                throw;
                        }
                    }
                }
                #endregion
            }
    
            private void Host_Connected(IAsyncResult result)
            {
                Connection conn = result.AsyncState as Connection;
    
                if (conn != null)
                {
                    lock (conn) //Need to set up variables and empty buffer, cant have the Client writing to the host stream during this time
                    {
                        try
                        {
                            conn.host_socket.EndConnect(result);
                            conn.host_stream = new NetworkStream(conn.host_socket);
                            conn.host_connected = true;
    
                            conn.buf_str.Position = 0;
                            conn.buf_str.CopyTo(conn.host_stream);
    
                            conn.host_stream.BeginRead(conn.host_buf_ary, 0, Buffer_Size, Host_Write, conn);
                        }
                        catch (Exception e)
                        {
                            if (!Handle_Disposed(e, conn))
                                throw;
                        }
                    }
                }
            }
    
            private void Host_Write(IAsyncResult result)
            {
                Connection conn = result.AsyncState as Connection;
    
                if (conn != null)
                {
                    try
                    {
                        int len = conn.host_stream.EndRead(result);
    
                        if (len == 0)
                        {
                            Close(conn);
                        }
                        else
                        {
                            try
                            {
                                conn.client_stream.Write(conn.host_buf_ary, 0, len);    //we want this to block
                            }
                            catch (Exception e_c)
                            {
                                if (!Handle_Disposed(e_c, conn))
                                    throw;
                            }
    
                            conn.host_stream.BeginRead(conn.host_buf_ary, 0, Buffer_Size, Host_Write, conn);
                        }
                    }
                    catch (Exception e_h)
                    {
                        if (!Handle_Disposed(e_h, conn))
                            throw;
                    }
                }
            }
    
            private void Close(Connection conn)
            {
                lock (conn)
                {
                    try
                    {
                        if (conn.host_connected)
                            conn.host_socket.Close();
                    }
                    catch { }
                    try
                    {
                        conn.client_tcp.Close();
                    }
                    catch { }
                }
            }
    
            private bool Handle_Disposed(Exception exp,Connection conn)
            {
                if (exp is ObjectDisposedException || (exp.InnerException != null && exp.InnerException is ObjectDisposedException))
                {
                    Close(conn);
                    return true;
                }
                else
                    return false;
            }
    
            private string ReadLine(MemoryStream str,Encoding encoding)    // Reads a line terminated by \r\n else returns resets postion and returns null
            {
                long idxA= str.Position;    //first position of line
                long idxB =-1;  //position after last char
    
                int b_last = str.ReadByte();
                int b_this = 0;
    
                for (long i = 1; i < str.Length; i++)
                {
                    b_this = str.ReadByte();
    
                    if (b_this == '\n' && b_last == '\r')
                    {
                        idxB = str.Position;
                        str.Position = idxA;
    
                        int len = (int)(idxB - idxA);
                        byte[] buf = new byte[len];
                        str.Read(buf, 0, len);
    
                        return encoding.GetString(buf);
                    }
                    else
                        b_last = b_this;
                }
    
                str.Position = idxA;
                return null;
            }
        }
    }
