    Byte[] b = new Byte[1024]; // Array of 1024 bytes
    
    List<byte> byteList; // List<T> of bytes
    
    // TODO: Receive bytes from TcpSocket into b
    
    foreach(var val in b) // Step through each byte in b
    {
    
        if(val != '0') // Your condition
        {
        }
        else
        {
            bytelist.Add(val); //Add the byte to the List
        }
    }
    bytelist.ToArray(); // Convert the List to an array of bytes
