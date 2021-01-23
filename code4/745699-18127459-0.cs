    [Serializable]
    public class MyObject {
      public int n1 = 0;
      public int n2 = 0;
      public String str = null;
    }
    // ... And in some other class where you have you application logic
    public void pack()
    {
        MyObject obj = new MyObject();
        obj.n1 = 1;
        obj.n2 = 24;
        obj.str = "Some String";
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, obj);
        stream.Close();
    }
