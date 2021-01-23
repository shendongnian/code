    ArrayList arrayListMem = new ArrayList() { "One", "Two", "Three", "Four", "Five", "Six", "Seven" };
    Console.WriteLine("Serializing to Memory : arrayListMem");
    byte[] stream = SerilizeDeserialize.Serialize(arrayListMem);
    ArrayList arrayListMemDes = new ArrayList();
    arrayListMemDes = SerilizeDeserialize.Deserialize<ArrayList>(stream);
        
    Console.WriteLine("DSerializing From Memory : arrayListMemDes");
    foreach (var item in arrayListMemDes)
    {
        Console.WriteLine(item);
    }
