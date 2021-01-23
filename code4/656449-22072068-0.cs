    internal sealed class SilentCryptoStream : CryptoStream
    {
        private readonly Stream underlyingStream;
    
        public SilentCryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode)
            : base(stream, transform, mode)
        {
            // stream is already implicitly validated non-null in the base constructor.
            this.underlyingStream = stream;
        }
    
        protected override void Dispose(bool disposing)
        {
            try
            {
                base.Dispose(disposing);
            }
            catch (CryptographicException)
            {
                if (disposing)
                {
                    this.underlyingStream.Dispose();
                }
            }
        }
    }
