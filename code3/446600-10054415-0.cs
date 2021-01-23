     public sealed class Block
     {
         private readonly Sector[] sectors = new Sector[128];
         public Sector this[int index] { get { return sectors[index]; } }
     }
     public sealed class Sector
     {
         private readonly byte[] data = new byte[8 * 1024];
         public byte this[int index]
         {
             get { return data[index]; }
             set { data[index] = value; }
         }
     }
