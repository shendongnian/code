    internal class DummyClass
    {
        private static void Dummy()
        {
            Noop(typeof(AbcDll.AnyClass));
        }
        private static void Noop(Type _) { }
    }
