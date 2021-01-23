    static class Helper
    {
       public static byte[] ToByteArray(this string str)
       {
          return System.Text.Encoding.ASCII.GetBytes(str);
       }
    }
