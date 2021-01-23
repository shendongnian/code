    public IEnumerable<BufferWrapper> getBytes(Stream stream)
    {
        List<int> bufferSizes = new List<int>() { 8192, 65536, 220160, 1048576 };
        int count = 0;
        int bufferSizePostion = 0;
        byte[] buffer = new byte[bufferSizes[0]];
        bool done = false;
        while (!done)
        {
            BufferWrapper nextResult = new BufferWrapper();
            nextResult.bytesRead = stream.Read(buffer, 0, buffer.Length);
            nextResult.buffer = buffer;
            done = nextResult.bytesRead == 0;
            if (!done)
            {
                yield return nextResult;
                count++;
                if (count > 10 && bufferSizePostion < bufferSizes.Count)
                {
                    count = 0;
                    bufferSizePostion++;
                    buffer = new byte[bufferSizes[bufferSizePostion]];
                }
            }
        }
    }
    public class BufferWrapper
    {
        public byte[] buffer { get; set; }
        public int bytesRead { get; set; }
    }
