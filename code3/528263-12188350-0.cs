    public class OwnedStream : Stream {
        private Stream stream;
        public OwnedStream(Stream stream) { this.stream = stream; }
        protected override void Dispose(bool disposing) {
            // Do nothing
        }
        public override bool CanRead { get { return stream.CanRead; } }
        // etcetera, just delegate to "stream"
    }
