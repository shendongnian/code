    public abstract class GenericClass<T>
    {
        private T _value;
        public void SetValue(T value)
        {
            _value = value;
        }
        public byte[] GetBytes()
        {
            return GetBytesInternal(_value);
        }
        protected abstract byte[] GetBytesInternal(T value);
    }
    public class IntClass : GenericClass<int>
    {
        protected override byte[] GetBytesInternal(int value)
        {
            return BitConverter.GetBytes(value);
        }
    }
    public class DoubleClass : GenericClass<double>
    {
        protected override byte[] GetBytesInternal(double value)
        {
            return BitConverter.GetBytes(value);
        }
    }
    public class FloatClass : GenericClass<float>
    {
        protected override byte[] GetBytesInternal(float value)
        {
            return BitConverter.GetBytes(value);
        }
    }
