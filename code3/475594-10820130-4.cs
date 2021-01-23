    const int BUFFER_SIZE = 0x8000;  //represents 32768 bytes
    public unsafe void parseCSV(string filePath)
    {
         byte[] buffer = new byte[BUFFER_SIZE];
         int workingSize = 0; //store how many bytes left in buffer
         int bufferSize = 0; //how many bytes were read by the file stream
         StringBuilder builder = new StringBuilder();
         char cByte; //character representation of byte
         using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
         {
             do
             {
                  bufferSize = fs.Read(buffer, 0, BUFFER_SIZE);
                  workingSize = bufferSize;
                  fixed (byte* bufferPtr = buffer)
                  {
                       byte* workingBufferPtr = bufferptr;
                       while (workingSize-- > 0)
                       {
                            switch (cByte = (char)*workingBufferPtr++)
                            {
                                case '\n':
                                    break;
                                case '\r':
                                case ',':
                                    builder.ToString();
                                    builder.Clear();
                                    break;
                                default:
                                    builder.Append(cByte);
                                    break;
                            }
                       }
                  }
             } while (bufferSize != 0);
         }
    }
