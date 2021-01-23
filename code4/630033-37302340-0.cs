     Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            soc.EnableBroadcast = true;
            IPEndPoint ipend = new IPEndPoint(IPAddress.Broadcast, 58717);
            EndPoint endp = (EndPoint)ipend;
            byte[] bytes = new byte[1024];
            bytes = Encoding.ASCII.GetBytes(str);
            soc.SendTo(bytes,ipend);
            soc.Close();
