    class MyClass<T>
    {
        static MyClass()
        {
            MyClass.DoXDelegates.Add(DoX);
        }
        public static void DoX() { /* whatever */ }
    }
    static class MyClass
    {
        private static readonly List<Action> s_DoXDelegates = new List<Action>();
        internal static List<Action> DoXDelegates
        {
            get { return s_DoXDelegates; }
        }
        internal static void DoXForAll()
        {
            foreach (var doXDelegate in DoXDelegates)
                doXDelegate();
        }
    }
