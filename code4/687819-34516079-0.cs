    public static class StringExtension
    {
         public static Stream ToStream(this string str)
           =>new memoryStream(Encoding.UTF8.GetBytes(str))         
         //Or much better
         public static Stream ToStreamWithEncoding(this string str, Encoding encoding)
           =>new memoryStream(encoding.GetBytes(str))
    }
