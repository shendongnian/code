    using(Socket clientSock=sock.Accept())
    {
        //This needs to be redone, see my first point
        int receivedBytesLen = clientSock.Receive(clientData);
        int fileNameLen = BitConverter.ToInt32(clientData, 0);
        string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);
        using(BinaryWriter bWrite = new BinaryWriter(File.Open(@"C:\Users\asd\Desktop\"+           fileName,FileMode.Append)))
        {
            bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
        }
    }
