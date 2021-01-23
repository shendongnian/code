    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using System.Net;
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading;
    
    
    
    
    namespace WebSocketServer
    {
        public enum ServerLogLevel { Nothing, Subtle, Verbose };
        public delegate void ClientConnectedEventHandler(WebSocketConnection sender, EventArgs e);
    
        public class WebSocketServer
        {
            #region private members
            private string webSocketOrigin;     // location for the protocol handshake
            private string webSocketLocation;   // location for the protocol handshake
            #endregion
            static private string guid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
            static IPEndPoint ipLocal;
    
            public event ClientConnectedEventHandler ClientConnected;
    
            /// <summary>
            /// TextWriter used for logging
            /// </summary>
            public TextWriter Logger { get; set; }     // stream used for logging
    
            /// <summary>
            /// How much information do you want, the server to post to the stream
            /// </summary>
            public ServerLogLevel LogLevel = ServerLogLevel.Subtle;
    
            /// <summary>
            /// Gets the connections of the server
            /// </summary>
            public List<WebSocketConnection> Connections { get; private set; }
    
            /// <summary>
            /// Gets the listener socket. This socket is used to listen for new client connections
            /// </summary>
            public Socket ListenerSocker { get; private set; }
    
            /// <summary>
            /// Get the port of the server
            /// </summary>
            public int Port { get; private set; }
    
    
            public WebSocketServer(int port, string origin, string location)
            {
                Port = port;
                Connections = new List<WebSocketConnection>();
                webSocketOrigin = origin;
                webSocketLocation = location;
            }
    
            /// <summary>
            /// Starts the server - making it listen for connections
            /// </summary>
            public void Start()
            {
                // create the main server socket, bind it to the local ip address and start listening for clients
                ListenerSocker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                ipLocal = new IPEndPoint(IPAddress.Loopback, Port);
                ListenerSocker.Bind(ipLocal);
                ListenerSocker.Listen(100);
    
    
    
                LogLine(DateTime.Now + "> server stated on " + ListenerSocker.LocalEndPoint, ServerLogLevel.Subtle);
    
                ListenForClients();
            }
    
            // look for connecting clients
            private void ListenForClients()
            {
                ListenerSocker.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
    
            private void OnClientConnect(IAsyncResult asyn)
            {
    
                byte[] buffer = new byte[1024];
                string headerResponse = "";
    
                // create a new socket for the connection
                var clientSocket = ListenerSocker.EndAccept(asyn);
                var i = clientSocket.Receive(buffer);
                headerResponse = (System.Text.Encoding.UTF8.GetString(buffer)).Substring(0, i);
                //Console.WriteLine(headerResponse);
    
    
                if (clientSocket != null)
                {
    
                    // Console.WriteLine("HEADER RESPONSE:"+headerResponse);
                    var key = headerResponse.Replace("ey:", "`")
                                  .Split('`')[1]                     // dGhlIHNhbXBsZSBub25jZQ== \r\n .......
                                  .Replace("\r", "").Split('\n')[0]  // dGhlIHNhbXBsZSBub25jZQ==
                                  .Trim();
                    var test1 = AcceptKey(ref key);
                    var newLine = "\r\n";
                    var name = "Charmaine";
                    var response = "HTTP/1.1 101 Switching Protocols" + newLine
                             + "Upgrade: websocket" + newLine
                             + "Connection: Upgrade" + newLine
                             + "Sec-WebSocket-Accept: " + test1 + newLine + newLine
                             + "Testing lang naman po:" + name
                             ;
    
    				// which one should I use? none of them fires the onopen method
    				clientSocket.Send(System.Text.Encoding.UTF8.GetBytes(response));
                }
    
    
    
    
    
                // keep track of the new guy
                var clientConnection = new WebSocketConnection(clientSocket);
                Connections.Add(clientConnection);
                // clientConnection.Disconnected += new WebSocketDisconnectedEventHandler(ClientDisconnected);
                Console.WriteLine("New user: " + ipLocal);
                // invoke the connection event
                if (ClientConnected != null)
                    ClientConnected(clientConnection, EventArgs.Empty);
    
                if (LogLevel != ServerLogLevel.Nothing)
                    clientConnection.DataReceived += new DataReceivedEventHandler(DataReceivedFromClient);
    
    
    
                // listen for more clients
                ListenForClients();
    
            }
    
            void ClientDisconnected(WebSocketConnection sender, EventArgs e)
            {
                Connections.Remove(sender);
                LogLine(DateTime.Now + "> " + sender.ConnectionSocket.LocalEndPoint + " disconnected", ServerLogLevel.Subtle);
            }
    
            void DataReceivedFromClient(WebSocketConnection sender, DataReceivedEventArgs e)
            {
                Log(DateTime.Now + "> data from " + sender.ConnectionSocket.LocalEndPoint, ServerLogLevel.Subtle);
                Log(": " + e.Data + "\n" + e.Size + " bytes", ServerLogLevel.Verbose);
                LogLine("", ServerLogLevel.Subtle);
            }
    
    
            /// <summary>
            /// send a string to all the clients (you spammer!)
            /// </summary>
            /// <param name="data">the string to send</param>
            public void SendToAll(string data)
            {
                Connections.ForEach(a => a.Send(data));
            }
    
            /// <summary>
            /// send a string to all the clients except one
            /// </summary>
            /// <param name="data">the string to send</param>
            /// <param name="indifferent">the client that doesn't care</param>
            public void SendToAllExceptOne(string data, WebSocketConnection indifferent)
            {
                foreach (var client in Connections)
                {
                    if (client != indifferent)
                        client.Send(data);
                }
            }
    
            /// <summary>
            /// Takes care of the initial handshaking between the the client and the server
            /// </summary>
    
    
            private void Log(string str, ServerLogLevel level)
            {
                if (Logger != null && (int)LogLevel >= (int)level)
                {
                    Logger.Write(str);
                }
            }
    
            private void LogLine(string str, ServerLogLevel level)
            {
                Log(str + "\r\n", level);
            }
    
            private static string AcceptKey(ref string key)
            {
                string longKey = key + guid;
                byte[] hashBytes = ComputeHash(longKey);
                return Convert.ToBase64String(hashBytes);
            }
            static SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            private static byte[] ComputeHash(string str)
            {
                return sha1.ComputeHash(System.Text.Encoding.ASCII.GetBytes(str));
            }
    
    
    
            private void ShakeHands(Socket conn)
            {
                using (var stream = new NetworkStream(conn))
                using (var reader = new StreamReader(stream))
                using (var writer = new StreamWriter(stream))
                {
                    //read handshake from client (no need to actually read it, we know its there):
                    LogLine("Reading client handshake:", ServerLogLevel.Verbose);
                    string r = null;
                    while (r != "")
                    {
                        r = reader.ReadLine();
                        LogLine(r, ServerLogLevel.Verbose);
                    }
    
                    // send handshake to the client
                    writer.WriteLine("HTTP/1.1 101 Web Socket Protocol Handshake");
                    writer.WriteLine("Upgrade: WebSocket");
                    writer.WriteLine("Connection: Upgrade");
                    writer.WriteLine("WebSocket-Origin: " + webSocketOrigin);
                    writer.WriteLine("WebSocket-Location: " + webSocketLocation);
                    writer.WriteLine("");
                }
    
    
                // tell the nerds whats going on
                LogLine("Sending handshake:", ServerLogLevel.Verbose);
                LogLine("HTTP/1.1 101 Web Socket Protocol Handshake", ServerLogLevel.Verbose);
                LogLine("Upgrade: WebSocket", ServerLogLevel.Verbose);
                LogLine("Connection: Upgrade", ServerLogLevel.Verbose);
                LogLine("WebSocket-Origin: " + webSocketOrigin, ServerLogLevel.Verbose);
                LogLine("WebSocket-Location: " + webSocketLocation, ServerLogLevel.Verbose);
                LogLine("", ServerLogLevel.Verbose);
    
                LogLine("Started listening to client", ServerLogLevel.Verbose);
                //conn.Listen();
            }
    
    
        }
    }
