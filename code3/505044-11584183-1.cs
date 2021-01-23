        string host = "encrypted.google.com";
        string proxy2 = "213.240.237.149";//host;
        int proxyPort2 = 3128;//443;
        string proxy = "180.183.236.63";//host;
        int proxyPort = 3128;//443;
        byte[] buffer = new byte[2048];
        int bytes;
        // Connect socket
        TcpClient client = new TcpClient(proxy, proxyPort);
        NetworkStream stream = client.GetStream();
        // Establish proxy-proxy tunnel
        byte[] tunnelRequest = Encoding.UTF8.GetBytes(String.Format("CONNECT {0}:{1}  HTTP/1.1\r\nHost:{0}\r\n\r\n", proxy2, proxyPort2));
        stream.Write(tunnelRequest, 0, tunnelRequest.Length);
        stream.Flush();
        // Read response to CONNECT request
        // There should be loop that reads multiple packets
        bytes = stream.Read(buffer, 0, buffer.Length);
        Console.Write(Encoding.UTF8.GetString(buffer, 0, bytes));
        // Wrap in SSL stream
        tunnelRequest = Encoding.UTF8.GetBytes(String.Format("CONNECT {0}:443  HTTP/1.1\r\nHost:{0}\r\n\r\n", host));
        stream.Write(tunnelRequest, 0, tunnelRequest.Length);
        stream.Flush();
        // Read response to CONNECT request
        // There should be loop that reads multiple packets
        bytes = stream.Read(buffer, 0, buffer.Length);
        Console.Write(Encoding.UTF8.GetString(buffer, 0, bytes));
        // Wrap SSL stream into SSL stream
        SslStream sslStream2 = new SslStream(stream);
        sslStream2.AuthenticateAsClient(host);
        // Send request
        byte[] request = Encoding.UTF8.GetBytes(String.Format("GET https://{0}/  HTTP/1.1\r\nHost: {0}\r\n\r\n", host));
        sslStream2.Write(request, 0, request.Length);
        sslStream2.Flush();
        // Read response
        do
        {
            bytes = sslStream2.Read(buffer, 0, buffer.Length);
            Console.Write(Encoding.UTF8.GetString(buffer, 0, bytes));
        } while (bytes != 0);
        client.Close();
        Console.ReadKey();
