    const int BUFFER_SIZE = 0x8000;  //represents 32768 bytes
    public unsafe void parseCSV(string filePath)
    {
         byte[] buffer = new byte[BUFFER_SIZE];
         int workingSize = 0; //store how many bytes left in buffer
         int bufferSize = 0; //how many bytes were read by the file stream
         StringBuilder builder = new StringBuilder();
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
                           if (*workingBufferPtr++ == (byte)',')
                           {
                               //Test if this is what you want
                               builder.ToString(); 
                               builder.Clear();
                           }
                           else
                           {
                               builder.Append((char)*workingBufferPtr);
                           }
                       }
                  }
             } while (bufferSize != 0);
         }
    }
