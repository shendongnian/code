    public sealed class MyTest
    {
        private int _value;
        public int Value {get { return _value; } }
        private MyTest(int value)
        {
           _value = value;
        }
        public static readonly MyTest A = new MyTest(1);
        public static readonly MyTest B = new MyTest(2);
    }
