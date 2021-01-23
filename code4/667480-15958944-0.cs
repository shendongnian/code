    public abstract class GenericClass<T>
    where T : struct
    {
        protected T _value;
        public void SetValue(T value)
        {
            this._value = value;
        }
        public abstract byte[] GetBytes();
    }
    public class IntGenericClass: GenericClass<int>
    {
        public override byte[] GetBytes()
        {
            return BitConverter.GetBytes(this._value);
        }
    }
