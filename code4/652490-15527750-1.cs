    public static class FooExts
    {
        public static IFoo Parse(this string xml)
        {
            return new Foo("derp");
        }
    }
