    public interface IChangeStruct
    {
        int Value { get; }
        void Change(int value);
    }
    public struct MyStruct : IChangeStruct
    {
        int value;
        public MyStruct(int _value)
        {
            value = _value;
        }
        public int Value
        {
            get
            {
                return value;
            }
        }
        public void Change(int value)
        {
            this.value = value;
        }
    }
