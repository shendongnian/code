    class StreamWriterThatDoesExtraStuffWhenClosed : StreamWriter
    {
        public StreamWriterThatDoesExtraStuffWhenClosed(string s) : base(s) { }
        protected override void Dispose(bool f) {
            base.Dispose(f);
            ... do whatever you like here ...
        }
    }
