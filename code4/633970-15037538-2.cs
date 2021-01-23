    byte[] fileAsBytes = File.ReadAllBytes(fileName);
    using(NetworkStream networkStream = tcpClient.GetStream())
    using(BinaryReader binaryReader = new BinaryReader(networkStream))
    using(BinaryWriter binaryWriter = new BinaryWriter(networkStream))
    {
         networkStream.ReadTimeout = timeout; //Set a timeout to stop the stream from reading indefinately           
         //To receive a byte array
         int incomingBytesLength = BinaryReader.ReadInt32();
         byte[] incomingBytes = BinaryReader.ReadBytes(incomingBytesLength);
         //To send a byte array
         BinaryWriter.Write(fileAsBytes.Length);
         BinaryWriter.Write(fileAsBytes);
    }
