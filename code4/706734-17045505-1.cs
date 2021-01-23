    // Using FileStream directly with a buffer and BlockCopy
    using (FileStream stream = new FileStream("file.dat", FileMode.Open))
    {
        // Read bytes from stream and interpret them as ints
        byte[] buffer = new byte[1024];
        int[] intArray = new int[buffer.Length >> 2]; // Each int is 4 bytes
        int count;
        // Read from the IO stream fewer times.
        while((count = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
           // Copy the bytes into the memory space of the Int32 array in one big swoop
           Buffer.BlockCopy(buffer, 0, intArray, count);
           for(int i=0; i<count; i+=4)
              Console.WriteLine(intArray[i]);
        }            
    }
