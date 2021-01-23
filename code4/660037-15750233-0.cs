    MemoryStream m = new MemoryStream();
    var formatter = new BinaryFormatter();
    formatter.Serialize(m, new MyClass() {Name="SO"});
    byte[] buf = m.ToArray();
    [Serializable]
    public class MyClass
    {
        public string Name;
    }
