    //Please note that if the file size is large enough. It may be preferred to use a stream instead of holding the entire file in memory.
    byte[] fileAsBytes = File.ReadAllBytes(fileName);
    using(NetworkStream networkStream = tcpClient.GetStream())
    using(BinaryReader binaryReader = new BinaryReader(networkStream))
    using(BinaryWriter binaryWriter = new BinaryWriter(networkStream))
    {
         networkStream.ReadTimeout = timeout; //Set a timeout to stop the stream from reading indefinately           
         //To receive a byte array
         int incomingBytesLength = BinaryReader.ReadInt32(); //The header is 4 bytes that lets us know how large the incoming byte[] is.
         byte[] incomingBytes = BinaryReader.ReadBytes(incomingBytesLength);
         //To send a byte array
         BinaryWriter.Write(fileAsBytes.Length); //Send a header of 4 bytes that lets the listener know how large the incoming byte[] is.
         BinaryWriter.Write(fileAsBytes);
    }
