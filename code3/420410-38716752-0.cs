    static private byte[] CreateFrame(string message, MessageType messageType = MessageType.Text, bool messageContinues = false)
        {
            byte b1 = 0;
            byte b2 = 0;
            switch (messageType)
            {
                case MessageType.Continuos:
                    b1 = 0;
                    break;
                case MessageType.Text:
                    b1 = 1;
                    break;
                case MessageType.Binary:
                    b1 = 2;
                    break;
                case MessageType.Close:
                    b1 = 8;
                    break;
                case MessageType.Ping:
                    b1 = 9;
                    break;
                case MessageType.Pong:
                    b1 = 10;
                    break;
            }
            b1 = (byte)(b1 + 128); // set FIN bit to 1
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            if (messageBytes.Length < 126)
            {
                b2 = (byte)messageBytes.Length;
            }
            else
            {
                if (messageBytes.Length < Math.Pow(2,16)-1)
                {                   
                    b2 = 126;
                }
                else
                {
                    b2 = 127;
                }
            }
            byte[] frame = null;
            if(b2 < 126)
            {
                frame = new byte[messageBytes.Length + 2];
                frame[0] = b1;
                frame[1] = b2;
                Array.Copy(messageBytes, 0, frame, 2, messageBytes.Length);
            }
            if(b2 == 126)
            {
                frame = new byte[messageBytes.Length + 4];
                frame[0] = b1;
                frame[1] = b2;
                byte[] lenght = BitConverter.GetBytes(messageBytes.Length);
                frame[2] = lenght[1];
                frame[3] = lenght[0];
                Array.Copy(messageBytes, 0, frame, 4, messageBytes.Length);
            }
            if(b2 == 127)
            {
                frame = new byte[messageBytes.Length + 10];
                frame[0] = b1;
                frame[1] = b2;
                byte[] lenght = BitConverter.GetBytes((long)messageBytes.Length);
                for(int i = 7, j = 2; i >= 0; i--, j++)
                {
                    frame[j] = lenght[i];
                }
            }
            return frame;
        }
