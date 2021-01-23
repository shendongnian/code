    abstract class Base<T>
        where T : Base<T>, new()
    {
        public static T GetObj()
        {
            return new T();
        }
    }
    class Derived : Base<Derived>
    {
        public Derived() { }
    }
