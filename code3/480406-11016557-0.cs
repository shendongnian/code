    static void Main(string[] args)
        {
            
            string host = "encrypted.google.com";
            // Connect socket
            TcpClient client = new TcpClient(host,443);
            NetworkStream stream = client.GetStream();
            // Wrap in SSL stream
            SslStream sslStream = new SslStream(stream);
            sslStream.AuthenticateAsClient(host);
            //Build request
            var sb = new StringBuilder();
            sb.AppendLine("GET / HTTP/1.1");
            sb.AppendLine(string.Format("Host: {0}", host));
            sb.AppendLine("Connection: keep-alive");
            sb.AppendLine("User-Agent: CSharp");
            sb.AppendLine("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            sb.AppendLine("Accept-Encoding: gzip,deflate,sdch");
            sb.AppendLine("Accept-Language: en-US,en;q=0.8");
            sb.AppendLine("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            sb.AppendLine();
            //Go go go!
            byte[] headerBytes = Encoding.UTF8.GetBytes(sb.ToString());
            sslStream.Write(headerBytes, 0, headerBytes.Length);
            sslStream.Flush();
            //Get a place to put it
            byte[] buffer = new byte[2048];
            int bytes;
            //Answer
            do
            {
                bytes = sslStream.Read(buffer, 0, buffer.Length);
                Console.Write(Encoding.UTF8.GetString(buffer, 0, bytes));
            } while (bytes != 0);
            //And done
            client.Close();
            Console.ReadKey();
            
        }
