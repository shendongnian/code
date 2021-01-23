    public string ReadMessage()
    {
        var header = new byte[1];
        // Read the header indicating the data length
        var bytesRead = ServerSocket.Receive(header);
        if (bytesRead > 0)
        {
            var dataLength = header[0];
            // If the message size is zero, return an empty string
            if (dataLength == 0) return string.Empty;
            var buffer = new byte[dataLength];
            var position = 0;
            while ((bytesRead = ServerSocket.Receive(buffer, position, buffer.Length - position, SocketFlags.None)) > 0)
            {
                // Advance the position by the number of bytes read
                position += bytesRead;
                // If there's still more data to read before we have a full message, call Receive again
                if (position < buffer.Length) continue;
                // We have a complete message - return it.
                return Encoding.UTF8.GetString(buffer);
            }
        }
        // If Receive returns 0, the socket has been closed, so return null to indicate this.
        return null;
    }
