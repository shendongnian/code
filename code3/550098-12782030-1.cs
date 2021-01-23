    static void Main(string[] args)
    {
      Person p1 = new Person();
      p1.ID = 1;
      p1.Name = "Test";
    
      byte[] bytes = ObjectToByteArray(p1);
    }
    private byte[] ObjectToByteArray(Object obj) 
    { 
      if(obj == null) 
        return null; 
      BinaryFormatter bf = new BinaryFormatter(); 
      MemoryStream ms = new MemoryStream(); 
      bf.Serialize(ms, obj); 
      return ms.ToArray(); 
    }
    [Serializable]
    public class Person
    {
      public int ID { get; set; }
      public string Name { get; set; }
    }
    
