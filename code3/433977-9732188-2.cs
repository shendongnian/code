    internal static class StaticFactory
    {
        public static Target Target = new Target();
        static StaticFactory()
        {
           Target.Init("foo");
        }
    }
