    class Program
    {
        static IEnumerable<string> GetGenericArgumentNames(Type type)
        {
            if (!type.IsGenericTypeDefinition)
            {
                type = type.GetGenericTypeDefinition();
            }
            foreach (var typeArg in type.GetGenericArguments())
            {
                yield return typeArg.Name;
            }
        }
        static void Main(string[] args)
        {
            // For a raw type
            Trace.WriteLine(string.Join(" ", GetGenericArgumentNames(typeof(Foo<>))));
            Trace.WriteLine(string.Join(" ", GetGenericArgumentNames(typeof(Foo<Quux>))));
        }
    }
    class Foo<TBar> {}
    class Quux {}
