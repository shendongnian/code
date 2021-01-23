    public class HttpStream : Stream
    {
        internal readonly Stream InnerStream;
        private long length;
        private bool canRead;
        internal bool Chunked { get; set; }
        internal int ChunkLength { get; set; }
        internal int ChunkReceivedPosition { get; set; }
        internal HttpStream(Stream innerStream)
        {
            InnerStream = innerStream;
            ChunkLength = -1;
            canRead = true;
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (!canRead)
                return -1;
            var bytesReadInCallSession = 0;
            if (Chunked)
            {
                do
                {
                    if (ChunkLength == -1)
                    {
                        // read next chunked content size
                        string chunkLengthString = InnerStream.ReadLine(returnLineEndBytes: false);
                        ChunkLength = Convert.ToInt32(chunkLengthString, 16);
                    }
                    // end of HTTP response-body
                    if (ChunkLength == 0)
                    {
                        canRead = false;
                        break;
                    }
                    int toRead = ChunkLength;
                    if (count + ChunkReceivedPosition - bytesReadInCallSession < ChunkLength)
                        toRead = count + ChunkReceivedPosition - bytesReadInCallSession;
                    // read chunked part
                    while (ChunkReceivedPosition < toRead)
                    {
                        var bytesRead = InnerStream.Read(buffer, offset + bytesReadInCallSession, toRead - ChunkReceivedPosition);
                        ChunkReceivedPosition += bytesRead;
                        bytesReadInCallSession += bytesRead;
                        Position += bytesRead;
                    }
                    if (ChunkReceivedPosition == ChunkLength)
                    {
                        // force to read next chunk size in next loop
                        ChunkLength = -1;
                        ChunkReceivedPosition = 0;
                        // discard anything until we reach after the first CR LF
                        InnerStream.ReadLine();
                    }
                    if (bytesReadInCallSession == count)
                        break;
                } while (true);
                if (!canRead)
                {
                    do
                    {
                        string trailer = InnerStream.ReadLine();
                        if (String.IsNullOrWhiteSpace(trailer))
                            break;
                        // TODO: process trailers
                    } while (true);
                }
                return bytesReadInCallSession;
            }
            else
            {
                var countRead = InnerStream.Read(buffer, offset, count);
                Position += countRead;
                return countRead;
            }
        }
        public override void SetLength(long value)
        {
            length = value;
        }
        public override bool CanRead
        {
            get { return canRead; }
        }
        public override long Length
        {
            get { return length; }
        }
        public override long Position
        {
            get;
            set;
        }
        public override void Flush()
        {
            throw new NotImplementedException();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
        public override bool CanSeek
        {
            get { throw new NotImplementedException(); }
        }
        public override bool CanWrite
        {
            get { throw new NotImplementedException(); }
        }
    }
