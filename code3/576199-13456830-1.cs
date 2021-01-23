    namespace Endian {
      using System;
      using System.IO;
    
      static class Program {
        static void Main() {
          int a = 2051;
      
          using (MemoryStream stream = new MemoryStream()) {
            using (BinaryWriter writer = new BinaryWriter(stream)) {
              writer.Write(a);
            }
      
            foreach (byte b in stream.ToArray()) {
              Console.Write("{0:X2} ", b);
            }
          }
      
          Console.WriteLine();
        }
      }
    }
