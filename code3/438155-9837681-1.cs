    public static class GuidEx
    {
        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }
    }
    public class MyClass
    {
        public void Foo()
        {
            Guid g;
            bool b;
            b = g.IsEmpty(); // true
            g = Guid.NewGuid();
            b = g.IsEmpty; // false
            b = Guid.Empty.IsEmpty(); // true
        }
    }
