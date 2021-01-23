    class Buffer
    {
        const int BUFFER_SIZE = 8 * 1024;
    
        public Buffer()
        {
            InUse = false;
            Bytes = new byte[BUFFER_SIZE];
        }
    
        public bool InUse { get; set; }
        public byte[] Bytes { get; private set; }
    }
