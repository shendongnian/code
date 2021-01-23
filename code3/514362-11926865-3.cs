    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
     
    namespace PolicyServer
    {
        // Encapsulate and manage state for a single connection from a client
        class PolicyConnection
        {
            private Socket _connection;
            private byte[] _buffer; // buffer to receive the request from the client       
            private int _received;
            private byte[] _policy; // the policy to return to the client
     
            // the request that we're expecting from the client
            private static string _policyRequestString = "<policy-file-request/>";
     
            public PolicyConnection(Socket client, byte[] policy)
            {
                _connection = client;
                _policy = policy;
     
                _buffer = new byte[_policyRequestString.Length];
                _received = 0;
     
                try
                {
                    // receive the request from the client
                    _connection.BeginReceive(_buffer, 0, _policyRequestString.Length, SocketFlags.None,
                        new AsyncCallback(OnReceive), null);
                }
                catch (SocketException)
                {
                    _connection.Close();
                }
            }
     
            // Called when we receive data from the client
            private void OnReceive(IAsyncResult res)
            {
                try
                {
                    _received += _connection.EndReceive(res);
     
                    // if we haven't gotten enough for a full request yet, receive again
                    if (_received < _policyRequestString.Length)
                    {
                        _connection.BeginReceive(_buffer, _received, _policyRequestString.Length - _received,
                            SocketFlags.None, new AsyncCallback(OnReceive), null);
                        return;
                    }
     
                    // make sure the request is valid
                    string request = System.Text.Encoding.UTF8.GetString(_buffer, 0, _received);
                    if (StringComparer.InvariantCultureIgnoreCase.Compare(request, _policyRequestString) != 0)
                    {
                        _connection.Close();
                        return;
                    }
     
                    // send the policy
                    Console.Write("Sending policy...\n");
                    _connection.BeginSend(_policy, 0, _policy.Length, SocketFlags.None,
                        new AsyncCallback(OnSend), null);
                }
                catch (SocketException)
                {
                    _connection.Close();
                }
            }
     
            // called after sending the policy to the client; close the connection.
            public void OnSend(IAsyncResult res)
            {
                try
                {
                    _connection.EndSend(res);
                }
                finally
                {
                    _connection.Close();
                }
            }
        }
     
        // Listens for connections on port 943 and dispatches requests to a PolicyConnection
        class PolicyServer
        {
            private Socket _listener;
            private byte[] _policy;
     
            // pass in the path of an XML file containing the socket policy
            public PolicyServer(string policyFilePath)
            {
     
                // Load the policy file
                FileStream policyStream = new FileStream(policyFilePath, FileMode.Open);
     
                _policy = new byte[policyStream.Length];
                policyStream.Read(_policy, 0, _policy.Length);
                policyStream.Close();
     
     
                // Create the Listening Socket
                _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                    ProtocolType.Tcp);
     
                _listener.SetSocketOption(SocketOptionLevel.Tcp, (SocketOptionName)
                    SocketOptionName.NoDelay, 0);
     
                _listener.Bind(new IPEndPoint(IPAddress.Any, 943));
                _listener.Listen(10);
     
                _listener.BeginAccept(new AsyncCallback(OnConnection), null);
            }
     
            // Called when we receive a connection from a client
            public void OnConnection(IAsyncResult res)
            {
                Socket client = null;
     
                try
                {
                    client = _listener.EndAccept(res);
                }
                catch (SocketException)
                {
                    return;
                }
     
                // handle this policy request with a PolicyConnection
                PolicyConnection pc = new PolicyConnection(client, _policy);
     
                // look for more connections
                _listener.BeginAccept(new AsyncCallback(OnConnection), null);
            }
     
            public void Close()
            {
                _listener.Close();
            }
        }
     
        public class Program
        {
            static void Main()
            {
                Console.Write("Starting...\n");
                PolicyServer ps =
                    new PolicyServer(@".\clientaccesspolicy.xml");
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            }
        }
    }
