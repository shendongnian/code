    public static class Extensions 
    {
        public static void TimesWhile(this int count, Func<bool> predicate, Action action)
        {
            for (int i = 0; i < count && predicate(); action()) {}
        }
        public static void TimesUntil(this int count, Func<bool> predicate, Action action)
        {
            for (int i = 0; i < count && !predicate(); action()) {}
        }
    }
