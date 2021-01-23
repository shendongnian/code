    public static T _<T>(this T o, Action<T> initialize) where T : class {
        initialize(o);
        return o;
    }
    var x = Builder.CreateItem()._(i => { i.Foo = "Bar"; i.Id = 1; });
