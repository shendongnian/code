    static class ByteExtensions
    {
        public static string DoSomething(this byte[] x)
        {
            return "Length of this byte array: " + x.Length;
        }
    }
    // ...
    void Foo()
    {
        var b = new byte[5];
        b.DoSomething();
    }
