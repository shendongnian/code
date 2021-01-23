    class XmlCleaner
        {
    
            public void Clean(Stream sourceStream, Stream targetStream)
            {
                const char openingIndicator = '<';
                const char closingIndicator = '>';
                const int bufferSize = 1024;
                long length = sourceStream.Length;
                char[] buffer = new char[bufferSize];
                bool startTagFound = false;
                StringBuilder writeBuffer = new StringBuilder();
    
                using(var reader = new StreamReader(sourceStream))            
                {
                    var writer = new StreamWriter(targetStream);
    
                    try
                    {
                        while (reader.Read(buffer, 0, bufferSize) > 0)
                        {
                            foreach (var c in buffer)
                            {
                                if (c == openingIndicator)
                                {
                                    if (startTagFound)
                                    {
                                        // we have 2 following opening tags without a closing one                                
                                        // just replace the first one
                                        writeBuffer = writeBuffer.Replace("<", "&lt;");
    
                                        // append the new one
                                        writeBuffer.Append(c);
                                    }
                                    else
                                    {
                                        startTagFound = true;
                                        writeBuffer.Append(c);
                                    }
                                }
                                else if (c == closingIndicator)
                                {
                                    startTagFound = false;
                                    // write writebuffer...
                                    writeBuffer.Append(c);
                                    writer.Write(writeBuffer.ToString());
                                    writeBuffer.Clear();
                                }
                                else
                                {
                                    writeBuffer.Append(c);
                                }
                            }
                        }
                    }
                    finally
                    {
                        // unfortunately the streamwriter's dispose method closes the underlying stream, so e just flush it
                        writer.Flush();
                    }                
                }
            }
