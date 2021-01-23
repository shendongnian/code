    [ProtoContract]
    public class BinaryFormatterSurrogate<T>
    {
        [ProtoMember(1)]
        public byte[] Raw { get; set; }
        public static explicit operator T(BinaryFormatterSurrogate<T> value)
        {
            if(value==null || value.Raw == null) return default(T);
            using(var ms = new MemoryStream(value.Raw))
            {
                return (T)new BinaryFormatter().Deserialize(ms);
            }
        }
        public static explicit operator BinaryFormatterSurrogate<T>(T value)
        {
            object obj = value;
            if (obj == null) return null;
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);
                return new BinaryFormatterSurrogate<T> { Raw = ms.ToArray() };
            }
            
        }
    }
