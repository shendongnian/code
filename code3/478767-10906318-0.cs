        public BinaryWriter(Stream output) : this(output, new UTF8Encoding(false, true)) 
        {
        } 
 
        public BinaryWriter(Stream output, Encoding encoding)
        { 
            if (output==null)
                throw new ArgumentNullException("output");
            if (encoding==null)
                throw new ArgumentNullException("encoding"); 
            if (!output.CanWrite)
                throw new ArgumentException(Environment.GetResourceString("Argument_StreamNotWritable")); 
            Contract.EndContractBlock(); 
            OutStream = output; 
            _buffer = new byte[16];
            _encoding = encoding;
            _encoder = _encoding.GetEncoder();
        } 
        protected virtual void Dispose(bool disposing)
        { 
            if (disposing) 
                OutStream.Close();
        } 
