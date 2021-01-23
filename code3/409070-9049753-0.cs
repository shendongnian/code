    [Serializable]
    public class DummyClass
    {
        public int Int1;
        public int Int2;
        public string String1;
        public double Double1;
        public int Int3;
    }
    void BinarySerialization()
    {
        MemoryStream m1 = new MemoryStream();
        BinaryFormatter bf1 = new BinaryFormatter();
        bf1.Serialize(m1, new DummyClass() { Int1=100,Int2=120,Int3=400,String1="Hello",Double1=3.1459});
        byte[] buf = m1.ToArray();
        BinaryFormatter bf2 = new BinaryFormatter();
        MemoryStream m2 = new MemoryStream(buf);
        DummyClass dummyClass = bf2.Deserialize(m2) as DummyClass;
    }
