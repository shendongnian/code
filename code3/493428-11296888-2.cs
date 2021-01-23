    class FooCollection : IEnumerable<Foo>, IEnumerable
    {
        SomeCollection<Foo> foos;
        // Explicit for IEnumerable because weakly typed collections are Bad
        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            // uses the strongly typed IEnumerable<T> implementation
            return this.GetEnumerator();
        }
        // Normal implementation for IEnumerable<T>
        IEnumerator<Foo> GetEnumerator()
        {
            foreach (Foo foo in this.foos)
            {
                yield return foo;
                //nb: if SomeCollection is not strongly-typed use a cast:
                // yield return (Foo)foo;
                // Or better yet, switch to an internal collection which is
                // strongly-typed. Such as List<T> or T[], your choice.
            }
            // or, as pointed out: return this.foos.GetEnumerator();
        }
    }
