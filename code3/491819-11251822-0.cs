    using (FileStream fsSource = new FileStream(pathSource,
            FileMode.Open, FileAccess.Read))
        {
            // Read the source file into a byte array.
            int numBytesToRead = // Your amount to read at a time
            byte[] bytes = new byte[numBytesToRead];
            
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                // Read may return anything from 0 to numBytesToRead.
                int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                // Break when the end of the file is reached.
                if (n == 0)
                    break;
                // Do here what you want to do with the bytes read (convert to string using Encoding.YourEncoding.GetString())
            }
        }
