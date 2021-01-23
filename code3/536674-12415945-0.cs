    public interface IOperations<T>
    {
        T Add(T a, T b);
        T Subtract(T a, T b);
        T Multiply(T a, T b);
        T Divide(T a, T b);
    }
    
    public static class Operations<T>
    {
        public static IOperations<T> Default { get { return Create<T>(); } }
        
        static IOperations<T> Create<T>()
        {
            var type = typeof(T);
            switch (Type.GetTypeCode(type))
            {
            case TypeCode.Byte:
                return (IOperations<T>)new ByteOperations();
            case TypeCode.Single:
                return (IOperations<T>)new SingleOperations();
            default:
                var message = String.Format("Operations for type {0} is not supported.", type.Name);
                throw new NotSupportedException(message);
            }
        }
        
        class ByteOperations : IOperations<byte>
        {
            public byte Add(byte a, byte b)      { return unchecked ((byte)(a + b)); }
            public byte Subtract(byte a, byte b) { return unchecked ((byte)(a - b)); }
            public byte Multiply(byte a, byte b) { return unchecked ((byte)(a * b)); }
            public byte Divide(byte a, byte b)   { return unchecked ((byte)(a / b)); }
        }
    
        class SingleOperations : IOperations<float>
        {
            public float Add(float a, float b)      { return a + b; }
            public float Subtract(float a, float b) { return a - b; }
            public float Multiply(float a, float b) { return a * b; }
            public float Divide(float a, float b)   { return a / b; }
        }
    }
