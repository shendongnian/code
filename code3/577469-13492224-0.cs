    private static void StartClient() {
            // Connect to a remote device.
            try {
                // Establish the remote endpoint for the socket.
                // The name of the 
                // remote device is "host.contoso.com".
                IPHostEntry ipHostInfo = Dns.Resolve("host.contoso.com");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
    
                // Create a TCP/IP socket.
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
    
                // Connect to the remote endpoint.
                client.BeginConnect( remoteEP, 
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();
    
                // Send test data to the remote device.
                Send(client,"This is a test<EOF>");
                sendDone.WaitOne();
    
                // Receive the response from the remote device.
                Receive(client);
                receiveDone.WaitOne();
    
                // Write the response to the console.
                Console.WriteLine("Response received : {0}", response);
    
                // Release the socket.
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
