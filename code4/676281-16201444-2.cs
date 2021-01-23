    class Program
    {
        // Your new function, (doesn't have to be static; just did it for the demo)
        // If you really really want to return object[][] still,
        // You'll need to pass an index to foo as well
        private static List<IList<object>> convert<T>(IList<T> dataList, Action<IList<object>, T> foo)
        {
            var arrayRes = new List<IList<object>>();
            foreach (var item in dataList)
            {
                var arrayObjProperty = new List<object>();
                foo(arrayObjProperty, item);
                arrayRes.Add(arrayObjProperty);
            }
            return arrayRes;
        }
        // The rest is just calling the function with two examples
        static void Main(string[] args)
        {
            var bar = new List<A>();
            bar.Add(new A() { name = "qux", year = 2013 });
            var objects1 = convert(bar, (a, b) =>
            {
                a.Add(b.name);
                a.Add(b.year);
            });
            var baz = new List<B>();
            baz.Add(new B() { code = "qux", id = 2013 });
            var objects2 = convert(baz, (a, b) =>
            {
                a.Add(b.code);
                a.Add(b.id);
            });
        }
    }
