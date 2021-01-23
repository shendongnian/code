    class JsonHackFilter : MemoryStream
    {
        private readonly Stream _outputStream = null;
        public JsonHackFilter(Stream output)
        {
            _outputStream = output;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            string bufferContent = Encoding.UTF8.GetString(buffer);
            // TODO: Manually manipulate the string here
            _outputStream.Write(Encoding.UTF8.GetBytes(bufferContent), offset,
                               Encoding.UTF8.GetByteCount(bufferContent));
            base.Write(buffer, offset, count);
        }       
    }
