    class ByteJoiner
    {
        private int i;
        public byte[] Bytes { get; private set; }
        public ByteJoiner(int totalBytes)
        {
            i = 0;
            Bytes = new byte[totalBytes];
        }
        public void Add(byte input)
        {
            Add(BitConverter.GetBytes(input));
        }
        public void Add(uint input)
        {
            Add(BitConverter.GetBytes(input));
        }
        public void Add(ushort input)
        {
            Add(BitConverter.GetBytes(input));
        }
        public void Add(byte[] input)
        {
            System.Buffer.BlockCopy(input, 0, Bytes, i, input.Length);
            i += input.Length;
        }
    }
