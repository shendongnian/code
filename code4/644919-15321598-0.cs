     public class ByteFieldList
        {
            private readonly List<byte> _interalBytes;
    
            public ByteFieldList()
                : this(4, 0)
            {
            }
    
            public ByteFieldList(byte fieldValue)
                : this(4, fieldValue)
            {
            }
    
    
            public ByteFieldList(int capacity, byte fieldValue)
            {
                FieldValue = fieldValue;
                _interalBytes = new List<byte>(capacity);
            }
    
    
            public byte FieldValue { get; set; }
    
            public ByteFieldList Add(byte b)
            {
                _interalBytes.Add(b);
                return this;
            }
    
            public void AddRange(byte[] bytes)
            {
                foreach (var b in bytes)
                    Add(b);
            }
    
    
            public ByteFieldList Remove(byte b)
            {
                _interalBytes.Remove(b);
                return this;
            }
    
            public byte this[int index]
            {
                get { return _interalBytes[index]; }
            }
    
            public byte[] GetAllInvalid()
            {
                return _interalBytes.ToArray();
            }   
    
        }
      public void Usage()
            {
                ByteFieldList byteFieldList = new ByteFieldList(5);
    
                byteFieldList.Add(5).Add(4).Add(8);
                byteFieldList.AddRange(new byte[] { 7, 89, 4, 32, 1 });
    
                var invalids = byteFieldList.GetAllInvalid(); // get 5, 4, 8, 7, 89, 4, 32, 1
    
                byteFieldList.FieldValue = 4;
    
            }
