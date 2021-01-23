    public class LargeFlagsEnum<T> where T : struct
    {
       private BitArray bits;
       public LargeFlagsEnum(int numBits)
       {
          if (!(typeof(T).IsEnum))
            throw new ArgumentException("Expected enum type");
          bits = new BitArray(numBits);
       }
       public byte[] GetBytes()
       {
          return bits.ConvertToByteArray();
       }
       public void Set(T flag, bool value)
       {
          bits[Convert.ToInt32(flag)] = value;
       }
       
       public bool Get(T flag)
       {
          return bits[Convert.ToInt32(flag)];
       }    
    }
    // Example:
    enum MyFlags
    {
       First = 1,
       SomethingElse = 280,    
    }
    class Example
    {
       void Main()
       {
          var someFlags = new LargeFlagsEnum<MyFlags>(281);
          someFlags.Set(MyFlags.SomethingElse, true);
          Transmit(someFlags.GetBytes()); 
       }
    }
