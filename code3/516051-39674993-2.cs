             Socket sck = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            sck.Connect(ip, port);
            sck.Send(Encoding.UTF8.GetBytes("GET / HTTP/1.0\r\n\r\n"));
            Console.WriteLine("SENT");
            string message = null;
            byte[] bytesStored = new byte[1048576];
            int k1 = sck.Receive(bytesStored);
            for (int i = 0; i < k1; i++)
            {
                message = message + Convert.ToChar(bytesStored[i]).ToString();
            }
            Console.WriteLine(message); // PRINT THE RESPONSE
