        private void startServer()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, serverPort));
            new Thread(() => StartListening(sck)).Start();
        }
        void StartListening(Socket socket)
        {
            socket.Listen(100);
            Accept(socket);
        }
        void Accept(Socket socket)
        {
            while (true)
            {
                Socket accepted = socket.Accept();
                Buffer = new byte[accepted.SendBufferSize];
                int bytesRead = accepted.Receive(Buffer);
                byte[] formatted = new byte[bytesRead];
                for (int i = 0; i < bytesRead; i++)
                {
                    formatted[i] = Buffer[i];
                }
                string command = Encoding.ASCII.GetString(formatted);
                string[] splittedCommand = command.Split(' ');
                jobsHistory.Items.Add(Encoding.ASCII.GetString(formatted));
                jobsHistory.Refresh();
                Process processToRun = new Process();
                processToRun.StartInfo.FileName = splittedCommand[0];
                processToRun.StartInfo.WorkingDirectory = Path.GetDirectoryName(splittedCommand[0]);
                processToRun.StartInfo.Arguments = "";
                for (int i = 1; i < splittedCommand.Length; i++)
                {
                    processToRun.StartInfo.Arguments += " " + splittedCommand[i];
                }
                processToRun.Start();
                accepted.Close();
            }
            // If you want to start listening again
            new Thread(() => StartListening(sck)).Start();
        }
