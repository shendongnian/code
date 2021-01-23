    public class Parent
    {
        public sealed void Foo(int n) { }
    }
    public class Child : Parent
    {
        public sealed void Foo(string s) { }
    }
