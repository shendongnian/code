    namespace StreamFilterTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var stringReader = new MemoryStream(Encoding.ASCII.GetBytes("<name>Me & You</name>"));
                var textReader = new AmpersandFilter(stringReader);
                //var result = textReader.ReadLine();
                
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                using (XmlReader xreader = XmlReader.Create(textReader, settings))
                {
                    while (xreader.Read())
                    {
                        Console.WriteLine(xreader.Value);
                    }
                }
    
                Console.ReadLine();
            }
        }
    
        /// <summary>
        /// This does not work as XMLReader does not call ReadLine
        /// </summary>
        class AmpersandFilterText : StreamReader
        {
            public AmpersandFilterText(Stream stream)
                : base(stream)
            {
            }
    
            public override string ReadLine()
            {
                var rawLine = base.ReadLine();
                rawLine = rawLine.Replace("&", "&amp;");
                return rawLine;
            }
        }
    
        class AmpersandFilter : Stream
        {
            public Stream InnerStream { get; private set; }
            private MemoryStream entityBuffer = new MemoryStream();
            private int entityBufferOffset = 0;
            private int entityBufferLength = 0;
    
            public AmpersandFilter(Stream innerStream)
            {
                this.InnerStream = innerStream;
            }
    
            public override bool CanRead
            {
                get { return InnerStream.CanRead || entityBufferLength > entityBufferOffset; }
            }
    
            public override bool CanSeek
            {
                get { return false; }
            }
    
            public override bool CanWrite
            {
                get { return false; }
            }
    
            public override void Flush()
            {
                throw new NotSupportedException();
            }
    
            public override long Length
            {
                get { throw new NotSupportedException(); }
            }
    
            public override long Position
            {
                get
                {
                    throw new NotSupportedException();
                }
                set
                {
                    throw new NotSupportedException();
                }
            }
    
            private int EntityBufferBytes { get { return entityBufferLength - entityBufferOffset; } }
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                // if there is data read from the internal stream pre-emptively, read from buffer, 
                // otherwise read from the stream
                int destPos = 0;
                if (EntityBufferBytes > 0)
                {
                    int bufferBytes = Math.Max(count, EntityBufferBytes);
                    entityBuffer.Read(buffer, entityBufferOffset, bufferBytes);
                    entityBufferOffset += bufferBytes;
                    destPos += bufferBytes;
    
                    // update for next read
                    // check if we exhausted the entire buffer
                    if (EntityBufferBytes == 0)
                    {
                        // go back to the begininning to prevent uncontrolled growth
                        entityBuffer.Seek(0, SeekOrigin.Begin);
                    }
                }
    
                // read the remainder from the base stream
                byte[] newData = new byte[count - destPos];
                int readBytes = InnerStream.Read(newData, 0, newData.Length);
    
                // loop and edit the results
                int sourcePos = 0;
                const byte amp = (byte)'&';
                // if the source file is UTF instead of ANSII, this should be changed
                byte[] ampEncoded = { (byte)'&', (byte)'a', (byte)'m', (byte)'p', (byte)';' };
                while (sourcePos < readBytes && destPos < count)
                {
                    //check if we need to expand
                    if (newData[sourcePos] == amp)
                    {
                        //TODO: check whether the next characters are valid XML entities
                        // expand the amp to the full entity
                        int encodedCopiedBytes = Math.Min(count - destPos, ampEncoded.Length);
                        Array.Copy(ampEncoded, 0, buffer, destPos + offset, encodedCopiedBytes);
    
                        //write the remainder to the buffer
                        if (encodedCopiedBytes < ampEncoded.Length)
                        {
                            entityBuffer.Write(ampEncoded, encodedCopiedBytes, ampEncoded.Length - encodedCopiedBytes);
                        }
    
                        // we advanced the source by the one entity byte and the destination by the replacement
                        sourcePos++;
                        destPos += encodedCopiedBytes;
                    }
                    //or whether we need to just copy
                    else
                    {
                        buffer[destPos + offset] = newData[sourcePos];
                        sourcePos++;
                        destPos++;
                    }
                }
    
                // if we have any data left, copy it to the buffer after escape
                for (; sourcePos < readBytes; sourcePos++)
                {
                    if (newData[sourcePos] == amp)
                    {
                        entityBuffer.Write(ampEncoded, 0, ampEncoded.Length);
                    }
                    else 
                    {
                        entityBuffer.WriteByte(newData[sourcePos]);
                    }
                }
    
                return destPos;
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }
    
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
        }
    }
