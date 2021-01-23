    const int BufferSize = 4096;
    const string newline = "\r\n";
    using (var strm = new StreamReader(....))
    {
        int newlineIndex = 0;
        var buffer = new char[BufferSize];
        StringBuilder sb = new StringBuilder();
        int charsInBuffer = 0;
        int bufferIndex = 0;
        char lastChar = (char)-1;
        while (!(strm.EndOfStream && bufferIndex >= charsInBuffer))
        {
            if (bufferIndex > charsInBuffer)
            {
                charsInBuffer = strm.Read(buffer, 0, buffer.Length);
                if (charsInBuffer == 0)
                {
                    // nothing read. Must be at end of stream.
                    break;
                }
                bufferIndex = 0;
            }
            if (buffer[bufferIndex] == newline[newlineIndex])
            {
                ++newlineIndex;
                if (newlineIndex == newline.Length)
                {
                    // found a line
                    Console.WriteLine(sb.ToString());
                    newlineIndex = 0;
                    sb = new StringBuilder();
                }
            }
            else
            {
                if (newlineIndex > 0)
                {
                    // copy matched newline characters
                    sb.Append(newline.Substring(0, newlineIndex));
                    newlineIndex = 0;
                }
                sb.Append(buffer[bufferIndex]);
            }
            ++bufferIndex;
        }
        // Might be a line left, without a newline
        if (newlineIndex > 0)
        {
            sb.Append(newline.Substring(0, newlineIndex));
        }
        if (sb.Length > 0)
        {
            Console.WriteLine(sb.ToString());
        }
    }
