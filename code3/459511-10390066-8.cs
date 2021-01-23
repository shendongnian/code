    public partial class MessageBase
    {
        // Virtual Execute method following the Command pattern
        public virtual string Execute(Socket socket) { return string.Empty; }
        protected virtual bool MustEncrypt
        {
            get { return false; }
        }
        // Binary serialization
        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (DeflateStream ds = new DeflateStream(stream, CompressionMode.Compress, true))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ds, this);
                    ds.Flush();
                }
                byte[] bytes = stream.GetBuffer();
                byte[] bytes2 = new byte[stream.Length];
                Buffer.BlockCopy(bytes, 0, bytes2, 0, (int)stream.Length);
    //                Array.Copy(bytes, bytes2, stream.Length);
                if (this.MustEncrypt)
                    bytes2 = RijndaelEncrptor.Instance.Encrypt(bytes2);
                // Create a buffer large enough to hold the encrypted message and size bytes
                byte[] data = new byte[8 + bytes2.Length];
                // Add the message size
                BitConverter.GetBytes(bytes2.Length).CopyTo(data, 0);
                BitConverter.GetBytes(this.MustEncrypt).CopyTo(data, 4);
                // Add the message data
                bytes2.CopyTo(data, 8);
                return data;
            }
        }
        static public MessageBase Deserialize(byte[] buffer)
        {
            int length = BitConverter.ToInt32(buffer, 0);
            bool mustDecrypt = BitConverter.ToBoolean(buffer, 4);
            MessageBase b = null;
            try
            {
                b = MessageBase.Deserialize(buffer, 8, length, mustDecrypt);
            }
            catch { }
            return b;
        }
        static public MessageBase Deserialize(byte[] buffer, int offset, int length, bool mustDecrypt)
        {
            // Create a buffer and initialize it with data from
            // the input buffer offset by the specified offset amount
            // and length determined by the specified length
            byte[] data = new byte[length];
            Buffer.BlockCopy(buffer, offset, data, 0, length);
    //            Array.Copy(buffer, offset, data, 0, length);
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
    //                        Array.Copy(state.Buffer, oldBuffer, state.BufferSize);
                        state.BufferSize = length + readOffset;
                        Buffer.BlockCopy(oldBuffer, 0, state.Buffer, 0, oldBuffer.Length);
    //                        Array.Copy(oldBuffer, state.Buffer, oldBuffer.Length);
                    }
                    // Ensure there are enough bytes to process the message
                    if (readOffset + length <= bufferLen)
                        yield return MessageBase.Deserialize(state.Buffer, readOffset, length, mustDecrypt);
                    else
                    {
                        // Add back the message length
                        readOffset -= 8;
                        // Reorder the receive buffer so unprocessed
                        // bytes are moved to the start of the array
                        Buffer.BlockCopy(state.Buffer, 0, state.Buffer, 0, bufferLen - readOffset);
    //                        Array.Copy(state.Buffer, state.Buffer, bufferLen - readOffset);
                        // Set the receive position to the current read position
                        // This is the offset where the next socket read will start
                        state.readOffset = bufferLen - readOffset;
                        break;
                    }
                    // Update the read position by the message length
                    readOffset += length;
                }
            }
        }
    }
