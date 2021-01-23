    using System;
    
    public class Test
    {
      public static void Main()
      {
        byte[] src = new byte[2] { 192, 85 };
        ushort[] tgt = new ushort[1];
    
        for ( int i = 0 ; i < src.Length ; i+=2 )
        {
          tgt[i] = (ushort)( ( src[i+1]<<8 | src[i] )>>6 );
        }
        System.Console.WriteLine( tgt[0].ToString() );
      }
    }
