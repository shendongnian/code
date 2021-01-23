    public interface IFirst
    {
        void F();
    }
    public interface ISecond
    {
        void S();
    }
    // Should the compiler pick this "overload"?
    public class My<T> where T : IFirst
    {
    }
    // Or this one?
    public class My<T> where T : ISecond
    {
    }
    public class Foo : IFirst, ISecond
    {
        public void Bar()
        {
            My<Foo> myFoo = new My<Foo>();
        }
        public void F() { }
        public void S() { }
    }
