    byte[] EndOfMessage = System.Text.Encoding.ASCII.GetBytes("image_end");
    byte[] ImageBytes = GetImageBytes();
    byte[] BytesToSend = new byte[EndOfMessage.Length + ImageBytes.Length];
    Array.Copy(ImageBytes, 0, BytesToSend);
    Array.Copy(EndOfMessage, 0, BytesToSend, ImageBytes.Length, EndOfMessage.Length);
    
    SendToServer(BytesToSend);
