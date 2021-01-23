    static class MyExtension
    {
        public static IEnumerable<Foo> OrderByFoo<T>(this List<Foo> list, IEnumerable<Foo> patern)
        {
            return list.OrderBy(p => p, new MyFooComparer(patern));
        }
    }
