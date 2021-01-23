    class C <T> where T : IA, new()
    {
      public T Data { get; set; }
      .....
    
      public UpdateReference()
      {
        byte[] data = GetBytesFromSomewhere();
        Data = AImpl.Deserialize(data);
    
        Data.UserfulMethod();
        Data.AnotherUserfulMethod();
        data = GetBytesFromSomewhere();
        Data = AImpl.Deserialize(data)
        Data.UserfulMethod();
        Data.AnotherUserfulMethod();
      }
    }
    
    public interface IA
    {
      public byte[] Serialize();
      public A Deserialize(byte[] data);
    
      public string UsefuleMethod1();
      public int AnotherUsefulMethod();
    }
    
    public class AImpl : IA
    {
      public byte[] Serialize()
      {
        //Concrete implementation serialization
      }
    
      public static IA Deserialize(byte[] data)
      {
        //Concrete implementation deserialization
      }
    }
