    public class WsdlAnnotationsFilterDecorator : Stream
    {
        private const string DefinitionsEndOfFileMarker = "</wsdl:definitions>";
        private const string SchemaEndOfFileMarker = "</xs:schema>";
        private readonly Stream inputStream;
        private readonly StringBuilder responseXml = new StringBuilder();
        private bool firstWrite = true;
        private string endOfFileMarker = DefinitionsEndOfFileMarker;
        public WsdlAnnotationsFilterDecorator(Stream inputStream)
        {
            this.inputStream = inputStream;
            this.responseXml = new StringBuilder();
        }
        public override bool CanRead { get { return true; } }
        public override bool CanSeek { get { return true; } }
        public override bool CanWrite { get { return true; } }
        public override long Length { get { return 0; } }
        public override long Position { get; set; }
        public override void Close()
        {
            inputStream.Close();
        }
        public override void Flush()
        {
            inputStream.Flush();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return inputStream.Seek(offset, origin);
        }
        public override void SetLength(long length)
        {
            inputStream.SetLength(length);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return inputStream.Read(buffer, offset, count);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            string valueToWrite = UTF8Encoding.UTF8.GetString(buffer, offset, count);
            SetEndOfFileMarker(valueToWrite);
            
            if (!valueToWrite.EndsWith(this.endOfFileMarker))
            {
                responseXml.Append(valueToWrite);
            }
            else
            {
                responseXml.Append(valueToWrite);
                
                string finalXml = responseXml.ToString();
                finalXml = WsdlAnnotator.Annotate(finalXml);
                byte[] data = UTF8Encoding.UTF8.GetBytes(finalXml);
                inputStream.Write(data, 0, data.Length);
            }
        }
        private void SetEndOfFileMarker(string valueToWrite)
        {
            if (firstWrite)
            {
                int definitionTagIndex = valueToWrite.IndexOf("<wsdl:definitions");
                int schemaTagIndex = valueToWrite.IndexOf("<xs:schema");
                if (definitionTagIndex > -1 || schemaTagIndex > -1)
                {
                    firstWrite = false;
                    if (definitionTagIndex > -1 && schemaTagIndex > -1)
                    {
                        endOfFileMarker =
                            definitionTagIndex < schemaTagIndex 
                                ? DefinitionsEndOfFileMarker : SchemaEndOfFileMarker;
                    }
                    else if (definitionTagIndex > -1)
                    {
                        endOfFileMarker = DefinitionsEndOfFileMarker;
                    }
                    else if (schemaTagIndex > -1)
                    {
                        endOfFileMarker = SchemaEndOfFileMarker;
                    }
                }
            }
        }
    }
