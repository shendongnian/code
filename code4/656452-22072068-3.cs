    internal sealed class SilentCryptoStream : CryptoStream
    {
        public SilentCryptoStream(Stream stream, ICryptoTransform transform, CryptoStreamMode mode)
            : base(stream, transform, mode)
        {
        }
    
        protected override void Dispose(bool disposing)
        {
            try
            {
                base.Dispose(disposing);
            }
            catch (CryptographicException)
            {
                // We don't care whether or not it was able to transform the final block.
                // If it did, then great!  If not, then oh well.
                // If you do want to throw if transforming the final block fails,
                // then call FlushFinalBlock() before trying to dispose this stream.
            }
        }
    }
