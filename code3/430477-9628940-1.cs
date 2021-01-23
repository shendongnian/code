    public static void Truncate(string file, int lines)
    {
        using (FileStream fs = File.Open(file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
        {
            fs.Position = fs.Length;
            // \n \r\n (both uses \n for lines)
            const int BUFFER_SIZE = 2048;
            // Start at the end until # lines have been encountered, record the position, then truncate the file
            long currentPosition = fs.Position;
            int linesProcessed = 0;
            byte[] buffer = new byte[BUFFER_SIZE];
            while (linesProcessed < linesToTruncate && currentPosition > 0)
            {
                int bytesRead = FillBuffer(buffer, fs);
                // We now have a buffer containing the later contents of the file
                for (int i = bytesRead - 1; i >= 0; i--)
                {
                     currentPosition--;
                     if (buffer[i] == '\n')
                     {
                         linesProcessed++;
                         if (linesProcessed == linesToTruncate)
                             break;
                     }
                }
            }
            // Truncate the file
            fs.SetLength(currentPosition);
        }
    }
    private static int FillBuffer(byte[] buffer, FileStream fs)
    {
        if (fs.Position == 0)
            return 0;
        int bytesRead = 0;
        int currentByteOffset = 0;
        // Calculate how many bytes of the buffer can be filled (remember that we're going in reverse)
        long expectedBytesToRead = (fs.Position < buffer.Length) ? fs.Position : buffer.Length;
        fs.Position -= expectedBytesToRead;
        while (bytesRead < expectedBytesToRead)
        {
            bytesRead += fs.Read(buffer, currentByteOffset, buffer.Length - bytesRead);
            currentByteOffset += bytesRead;
        }
        // We have to reset the position again because we moved the reader forward;
        fs.Position -= bytesRead;
        return bytesRead;
    }
