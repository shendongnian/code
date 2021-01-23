    class Program
    {
        static void Main(string[] args)
        {
            // For a raw type
            Trace.WriteLine(typeof (Foo<>)
                                .GetGenericArguments()[0]
                                .Name);
            // For a parameterized type
            Trace.WriteLine(typeof (Foo<Quux>)
                                .GetGenericTypeDefinition()
                                .GetGenericArguments()[0]
                                .Name);
        }
    }
    class Foo<TBar> {}
    class Quux {}
