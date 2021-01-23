        public interface IHasInt
        {
            int TheInt { get; }
        }
        public class MyClass : IHasInt
        {
            public int TheInt { get; private set; }
            public MyClass()
            {
                TheInt = 123;
            }
        }
