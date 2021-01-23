    public static class Extensions {
            public static bool In<T>(this T needle, params T[] haystack){
                return haystack.Contains(needle);
            }
        }
    string x = "foo";
    if (x.In("bar", "baz", "foo", "foobar")) {
