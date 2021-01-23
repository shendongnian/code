    public static class ClassTwo
    {
        private static IClass _someProperty;
        public static Func<IClass> ResolveProperty { private get; set; }
        private static IClass SomeProperty
        {
            get { return _someProperty ?? (_someProperty = ResolveProperty()); }
        }
        public static void SomeOtherMethod()
        {
            SomeProperty.AnotherMethod();
        }
    }
