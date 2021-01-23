    class Vector<T> { ... }
    static class Vector
    {
        public static T Create<T>(T value)
        {
            return new Vector<T>(value);
        }
    }
    class OtherClass
    {
        public static Vector<int> MyVector = Vector.Create(1);
    }
