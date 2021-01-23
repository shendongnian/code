    class GermanEncoding : Encoding {
    
      static readonly Encoding iso88791Encoding = Encoding.GetEncoding("ISO-8859-1");
    
      static readonly Dictionary<Char, Char> charMappingTable = new Dictionary<Char, Char> {
        { 'À', 'A' },
        { 'Á', 'A' },
        { 'Â', 'A' },
        { 'ç', 'c' },
        // Add more mappings
      };
    
      static readonly Dictionary<Byte, Byte> byteMappingTable = charMappingTable
        .ToDictionary(kvp => MapCharToByte(kvp.Key), kvp => MapCharToByte(kvp.Value));
    
      public override Int32 GetByteCount(Char[] chars, Int32 index, Int32 count) {
        return iso88791Encoding.GetByteCount(chars, index, count);
      }
    
      public override Int32 GetBytes(Char[] chars, Int32 charIndex, Int32 charCount, Byte[] bytes, Int32 byteIndex) {
        var count = iso88791Encoding.GetBytes(chars, charIndex, charCount, bytes, byteIndex);
        for (var i = byteIndex; i < byteIndex + count; ++i)
          if (byteMappingTable.ContainsKey(bytes[i]))
            bytes[i] = byteMappingTable[bytes[i]];
        return count;
      }
    
      public override Int32 GetCharCount(Byte[] bytes, Int32 index, Int32 count) {
        return iso88791Encoding.GetCharCount(bytes, index, count);
      }
    
      public override Int32 GetChars(Byte[] bytes, Int32 byteIndex, Int32 byteCount, Char[] chars, Int32 charIndex) {
        return iso88791Encoding.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
      }
    
      public override Int32 GetMaxByteCount(Int32 charCount) {
        return iso88791Encoding.GetMaxByteCount(charCount);
      }
    
      public override Int32 GetMaxCharCount(Int32 byteCount) {
        return iso88791Encoding.GetMaxCharCount(byteCount);
      }
    
      static Byte MapCharToByte(Char c) {
        // NOTE: Assumes that each character encodes as a single byte.
        return iso88791Encoding.GetBytes(new[] { c })[0];
      }
    
    }
