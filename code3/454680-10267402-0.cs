    public class Foo
    {
        protected virtual int SIZE
        {
            get
            {
                return 2;
            }
        }
        private int[] array;
        public Foo()
        {
            array = new int[SIZE];
        }
    }
    public class Bar : Foo
    {
        protected override int SIZE
        {
            get
            {
                return 4;
            }
        }
    }
