    class MyStream : Stream
    {
        public MyStream(Stream baseStream) { this.baseStream = baseStream; }
        private Stream baseStream;
        // Delegate all operations except Seek/CanSeek to baseStream
        public override bool CanSeek { get { return true; } }
        public override long Seek(long offset, SeekOrigin origin) { return baseStream.Position; }
    }
