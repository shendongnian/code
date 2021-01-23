    public class MyFirstParameter {
      public byte[] Bytes { get; private set; }
      private MyFirstParameter (byte[] bytes){
        Bytes = bytes;
      }
      public static implicit operator MyFirstParameter(int value) {
        return new MyFirstParameter(BitConverter.GetBytes(value));
      }
      public static implicit operator MyFirstParameter(long value) {
        return new MyFirstParameter(BitConverter.GetBytes(value));
      }
      // and a few more types
    }
