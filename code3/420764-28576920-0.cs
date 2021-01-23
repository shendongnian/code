    namespace System
    {
      public static class StringExt
      {
        public static unsafe void ReplaceAt(this string source, int index, char value)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (index < 0 || index >= source.Length)
                throw new IndexOutOfRangeException("invalid index value");
            fixed (char* ptr = source)
            {
                ptr[index] = value;
            }
        }
      }
    }
