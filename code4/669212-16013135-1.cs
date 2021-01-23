    public void SerializeMySpecialData()
    {
        System.IO.Stream myStream = new System.IO.MemoryStream();
        // in this case: read and write using only memory.
        // if you want to write to something else, for instance a file,
        // create a file stream.
        // or any other subclass from Sytem.IO.Stream. The serializer won't notice
        // where it is actually stored.
        MySerializer mySerializer = new MySerializer(myStream);
        mySerializer.Serialize(mySpecialData);
        myStream.Flush();
        myStream.Close();
        myStream.Dispose(); // this function will probably also flush and close
    }
