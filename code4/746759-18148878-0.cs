    // responseData string will be the barcode received from reader
    string responseData = null;
    using (TcpClient client = new TcpClient("10.90.10.36", 2001))
    {
        using (NetworkStream stream = client.GetStream())
        {
            byte[] sentData = System.Text.Encoding.ASCII.GetBytes("getData");
            stream.Write(sentData, 0, sentData.Length);
            byte[] buffer = new byte[32];
            int bytes;
            while ((bytes = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                for (int i = 0; i < bytes; i++)
                {
                    responseData += (char)buffer[i];
                }
            }
        }
    }
