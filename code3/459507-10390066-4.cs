            // Decrypt message
            if (mustDecrypt)
                data = RijndaelEncrptor.Instance.Decrypt(data);
            // Deserialize the binary data into a new object of type MessageBase
            using (MemoryStream stream = new MemoryStream(data))
            {
                using (DeflateStream ds = new DeflateStream(stream, CompressionMode.Decompress, false))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    try
                    {
                        return formatter.Deserialize(ds) as MessageBase;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
        static public IEnumerable<MessageBase> Receive(Socket client, int bytesReceived, StateObject state)
        {
            // Total buffered count is the bytes received this read
            // plus any unprocessed bytes from the last receive
            int bufferLen = bytesReceived + state.readOffset;
            // Reset the next read offset in the case
            // this recieve lands on a message boundary
            state.readOffset = 0;
            // Make sure there are bytes to read
            if (bufferLen >= 0)
            {
                // Initialize the current read position
                int readOffset = 0;
                // Process the receive buffer
                while (readOffset < bufferLen)
                {
                    // Get the message size
                    int length = BitConverter.ToInt32(state.Buffer, readOffset);
                    bool mustDecrypt = BitConverter.ToBoolean(state.Buffer, readOffset + 4);
                    // Increment the current read position by the length header
                    readOffset += 8;
                    // Change the buffer size if necessary
                    if (length + readOffset > state.Buffer.Length)
                    {
                        byte[] oldBuffer = new byte[state.BufferSize];
                        Buffer.BlockCopy(state.Buffer, 0, oldBuffer, 0, state.BufferSize);
