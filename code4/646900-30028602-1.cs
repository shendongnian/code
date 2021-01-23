    private void ShakeHands(Socket conn)
        {
            using (var stream = new NetworkStream(conn))
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream))
            {
                //read handshake from client (no need to actually read it, we know its there):
                LogLine("Reading client handshake:", ServerLogLevel.Verbose);
                string r = null;
                Dictionary<string, string> headers = new Dictionary<string, string>();
                while (r != "")
                {
                    r = reader.ReadLine();
                    string[] tokens = r.Split(new char[] { ':' }, 2);
                    if (!string.IsNullOrWhiteSpace(r) && tokens.Length > 1)
                    {
                        headers[tokens[0]] = tokens[1].Trim();
                    }
                    LogLine(r, ServerLogLevel.Verbose);
                }
                
                //string line = string.Empty;
                //while ((line = reader.ReadLine()) != string.Empty)
                //{
                //    string[] tokens = line.Split(new char[] { ':' }, 2);
                //    if (!string.IsNullOrWhiteSpace(line) && tokens.Length > 1)
                //    {
                //        headers[tokens[0]] = tokens[1].Trim();
                //    }
                //}
                string responseKey = "";
                string key = string.Concat(headers["Sec-WebSocket-Key"], "258EAFA5-E914-47DA-95CA-C5AB0DC85B11");
                using (SHA1 sha1 = SHA1.Create())
                {
                    byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(key));
                    responseKey = Convert.ToBase64String(hash);
                }
                // send handshake to the client
                writer.WriteLine("HTTP/1.1 101 Web Socket Protocol Handshake");
                writer.WriteLine("Upgrade: WebSocket");
                writer.WriteLine("Connection: Upgrade");
                writer.WriteLine("WebSocket-Origin: " + webSocketOrigin);
                writer.WriteLine("WebSocket-Location: " + webSocketLocation);
                //writer.WriteLine("Sec-WebSocket-Protocol: chat");
                writer.WriteLine("Sec-WebSocket-Accept: " + responseKey);
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
