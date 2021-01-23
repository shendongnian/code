    public static string GetCallerName([CallerMemberName] string name = null) {
        return name;
    }
    ...
    public string Foo {
        get {
            ...
            var myName = GetCallerName(); // "Foo"
            ...
        }
        set { ... }
    }
