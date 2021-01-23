    class PositionWrapperStream : Stream
    {
        private readonly Stream wrapped;
        private int pos = 0;
        public PositionWrapperStream(Stream wrapped)
        {
            this.wrapped = wrapped;
        }
        public override bool CanSeek { get { return false; } }
        public override bool CanWrite { get { return true; } }
        public override long Position
        {
            get { return pos; }
            set { throw new NotSupportedException(); }
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            pos += count;
            wrapped.Write(buffer, offset, count);
        }
        public override void Flush()
        {
            wrapped.Flush();
        }
        protected override void Dispose(bool disposing)
        {
            wrapped.Dispose();
            base.Dispose(disposing);
        }
        // all the other required methods can throw NotSupportedException
    }
