    class TestProgram
    {
        static void Main(string[] args)
        {
            var stringReader = new MemoryStream(Encoding.ASCII.GetBytes("<name>Me & You</name>"));
            var textReader = new AmpersandFilterText(stringReader);
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
    class AmpersandFilterText : StreamReader
    {
        public AmpersandFilterText(Stream stream)
            : base(stream)
        {
        }
        private StringBuilder sbBuffer = null;
        private int bufferOffset = 0;
        public override string ReadLine()
        {
            var rawLine = base.ReadLine();
            rawLine = rawLine.Replace("&", "&amp;");
            return rawLine;
        }
        public override int Read()
        {
            char cChar;
            if (sbBuffer != null)
            {
                cChar = sbBuffer[bufferOffset];
                bufferOffset++;
                evalBuffer();
                return cChar;
            }
            else
            {
                cChar = (char)base.Read();
                if (cChar == '&')
                    sbBuffer = new StringBuilder("amp;");
                return cChar;
            }
        }
        public override int Read(char[] buffer, int index, int count)
        {
            int destOffset = 0;
            const string replacement = "&amp;";
            //exhaust our buffer first
            if (sbBuffer != null)
            {
                int bufferedToConsume = Math.Min(count, sbBuffer.Length - bufferOffset);
                sbBuffer.CopyTo(bufferOffset, buffer, index, bufferedToConsume);
                destOffset += bufferedToConsume;
                bufferOffset += bufferedToConsume;
                evalBuffer();
            }
            //then, if needed, read more data
            if (destOffset < count)
            {
                char[] newBuffer = new char[count - destOffset];
                var newRead = base.Read(newBuffer, 0, newBuffer.Length);
                //process new data and return directly
                int sourceOffset = 0;
                while (sourceOffset < newRead && destOffset < count)
                {
                    char tChar = newBuffer[sourceOffset];
                    if (tChar == '&')
                    {
                        int replacementOffset = 0;
                        while (replacementOffset < replacement.Length && destOffset < count)
                        {
                            buffer[destOffset + index] = replacement[replacementOffset];
                            destOffset++;
                            replacementOffset++;
                        }
                        sourceOffset++;
                        //we did not copy the entire replacement
                        if (replacementOffset < replacement.Length)
                        {
                            //put the remainder in next time
                            sbBuffer = new StringBuilder();
                            sbBuffer.Append(replacement, replacementOffset, replacement.Length - replacementOffset);
                        }
                    }
                    else
                    {
                        buffer[destOffset + index] = tChar;
                        destOffset++;
                        sourceOffset++;
                    }
                }
                //we have unused data
                if (sourceOffset < newRead)
                {
                    if (sbBuffer == null)
                        sbBuffer = new StringBuilder();
                    //add data after replace
                    for (; sourceOffset < newRead; sourceOffset++)
                    {
                        char tChar = newBuffer[sourceOffset];
                        if (tChar == '&')
                            sbBuffer.Append(replacement);
                        else
                            sbBuffer.Append(tChar);
                    }
                }
            }
            return destOffset;
        }
        public override int ReadBlock(char[] buffer, int index, int count)
        {
            return this.Read(buffer, index, count);
        }
        public override int Peek()
        {
            if (sbBuffer != null)
                return sbBuffer[bufferOffset];
            return base.Peek();
        }
        public override string ReadToEnd()
        {
            string cLine;
            StringBuilder sbTemp = new StringBuilder();
            while ((cLine = this.ReadLine()) != null)
                sbTemp.AppendLine(cLine);
            return sbTemp.ToString();
        }
        private void evalBuffer()
        {
            if (bufferOffset == sbBuffer.Length)
            {
                //TODO: check perf on sbBuffer.Clear
                sbBuffer = null;
                bufferOffset = 0;
            }
        }
    }
