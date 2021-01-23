    MemoryStream m = new MemoryStream();
    var formatter = new BinaryFormatter();
    formatter.Serialize(m, new MyClass() {Name="SO"});
    byte[] buf = m.ToArray(); //or File.WriteAllBytes(filename, m.ToArray())
    [Serializable]
    public class MyClass
    {
        public string Name;
    }
