            Socket client_s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 4567);
            client_s.Connect(serverEP);
            NetworkStream stream = new NetworkStream(client_s);
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            stream.Flush(); //flush everything
