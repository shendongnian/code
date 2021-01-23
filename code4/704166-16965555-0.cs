    public struct Data
    {
        public int val;
    }
    public class Foo
    {
        public Data Data;
        void method(Foo foo)
        {
            foo.Data.val = 10;
        }
    }
