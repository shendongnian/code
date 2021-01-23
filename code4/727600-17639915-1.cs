    public interface I {}
    public struct S : I {}
    public class Foo
    {
        public static void Bar<T>(T i)
            where T : I
        {}
    }
