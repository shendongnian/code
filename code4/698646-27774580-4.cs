        public class TestClass<T>
        {
            public TestClass(T value1, T value2)
            {
                Value1 = value1;
                Value2 = value2;
            }
            public T Value1 { get; private set; }
            public T Value2 { get; private set; }
        }
        public class SimilarClass<T>
        {
            public SimilarClass(T value1, T value2)
            {
                Value1 = value1;
                Value2 = value2;
            }
            public T Value1 { get; private set; }
            public T Value2 { get; private set; }
        }
