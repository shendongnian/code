       public class CountingStream : System.IO.FileStream {
    
          // provide appropriate constructors
    
          // may want to override BeginRead too
    
          // not thread safe
     
          private long _Counter = 0;
    
          public override int ReadByte() {
             _Counter++;
             return base.ReadByte();            
          }
    
          public override int Read(byte[] array, int offset, int count) {
             // check if not going over the end of the stream
             _Counter += count;
             return base.Read(array, offset, count);             
          }
    
          public long BytesReadSoFar {
             get {
                return _Counter;
             }
          }
       }
