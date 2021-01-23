    void Main()
    {
        var singleFoo = new Foo();
        var multipleFoos = new[] { new Foo(), new Foo(), new Foo() };
        var count = DoStuffWithFoos(singleFoo.Listify(), multipleFoos).Count();
        Console.WriteLine("Total Foos: " + count.ToString());
    }
    
    public class Foo { }
    
    public IEnumerable<Foo> DoStuffWithFoos(params IEnumerable<Foo>[] fooLists)
    {
        return fooLists.SelectMany(fl => fl); // this flattens all your fooLists into
                                              // a single list of Foos
    }
    
    public static class ExtensionMethods
    {
        public static IEnumerable<Foo> Listify(this Foo foo)
        {
            yield return foo;
        }
    }
