    class PositionWrapperStream : Stream
    {
        private readonly Stream wrapped;
        private long pos = 0;
        public PositionWrapperStream(Stream wrapped)
        {
            this.wrapped = wrapped;
        }
        public override bool CanSeek
        {
            get { return false; }
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override long Position
        {
            get { return pos; }
            set { throw new NotSupportedException(); }
        }
        public override bool CanRead
        {
            get { return wrapped.CanRead; }
        }
        public override long Length
        {
            get { return wrapped.Length; }
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
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    pos = 0;
                    break;
                case SeekOrigin.End:
                    pos = Length - 1;
                    break;
            }
            pos += offset;
            return wrapped.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            wrapped.SetLength(value);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            pos += offset;
            int result = wrapped.Read(buffer, offset, count);
            pos += count;
            return result;
        }
    }
