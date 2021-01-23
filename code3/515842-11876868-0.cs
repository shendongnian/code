        /// <summary>
        /// Starts a video.
        /// </summary>
        /// <param name="url">The URL of the video to play.</param>
        /// <param name="startPosition">The start position of the video. This value must be between 0 and 1</param>
        public void StartVideo(Uri url, float startPosition = 0)
        {
            if (startPosition > 1)
            {
                throw new ArgumentException("Start Position must be between 0 and 1");
            }
            TcpClient tcpClient = new TcpClient("192.168.1.20", 7000);
            tcpClient.ReceiveTimeout = 100000;
            tcpClient.SendTimeout = 100000;
            //get the client stream to read data from.
            NetworkStream clientStream = tcpClient.GetStream();
            string body =
           "Content-Location: " + url + "\n" +
           "Start-Position: " + startPosition + "\n";
            string request = "POST /play HTTP/1.1\n" +
            "User-Agent: MediaControl/1.0\n" +
            "Content-Type: text/parameters\n" +
            "Content-Length: " + Encoding.ASCII.GetBytes(body).Length + "\n" +
            "X-Apple-Session-ID:" + _sessionGuid.ToString() + "\n\n";
            //Send the headers
            sendMessage(clientStream, request);
            //Send the body
            sendMessage(clientStream, body);
            //Get the response
            byte[] myReadBuffer = new byte[1024];
            StringBuilder myCompleteMessage = new StringBuilder();
            int numberOfBytesRead = 0;
            numberOfBytesRead = clientStream.Read(myReadBuffer, 0, myReadBuffer.Length);
            myCompleteMessage.Append(Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
            //Now start doing a "keepalive"
            while (true)
            {
                //Simply send the characters "ok" every two seconds
                sendMessage(clientStream, "ok");
                Thread.Sleep(2000);
            }                      
        }
        /// <summary>
        /// Sends a message across the NetworkStream
        /// </summary>
        /// <param name="clientStream">The stream to send the message down</param>
        /// <param name="message">The message to send</param>
        public void sendMessage(NetworkStream clientStream, string message)
        {
            byte[] buffer = new ASCIIEncoding().GetBytes(message);
            try
            {
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
            catch (System.IO.IOException e)
            {
                Debug.WriteLine("IOException: " + e.Message);
            }
        }
