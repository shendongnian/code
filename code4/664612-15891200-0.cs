            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.Connect(tracker, port);
            byte[] conPacket = new byte[16];
            byte[] temp = BitConverter.GetBytes(0x41727101980).Reverse().ToArray();
            byte[] temp2 = BitConverter.GetBytes(0);
            byte[] temp3 = BitConverter.GetBytes(new Random().Next(0, 65535));
            Array.Copy(temp, 0, conPacket, 0, 8);
            Array.Copy(temp2, 0, conPacket, 8, 4);
            Array.Copy(temp3, 0, conPacket, 12, 4);
            //Connect to the protocol
            client.Send(conPacket);
            byte[] response = new byte[16];
            client.Receive(response);
