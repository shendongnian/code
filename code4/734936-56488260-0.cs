        public void Send(String message)
        {
            try
            {
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = Encoding.ASCII.GetBytes(message);
                // Get a client stream for reading and writing.
                NetworkStream stream = Client.GetStream();
                stream.Write(data, 0, data.Length);
                 stream.Close(); // this also closses the connection the server!
            }
            catch (Exception e)
            {
                LogException(e);
            }
        }
