    public static class RubyExt
    {
        public static void Unless(this Action action, bool condition)
        {
            if (!condition)
                action.Invoke();
        }
    }
