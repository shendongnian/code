    public static class DoLaterExtension
    {
        public static void DoLater<T>(this T x, int delay, Action<T> action)
        {
            // TODO: Impelement timer logic
            action.Invoke(x);
        }
    }
    private void Example()
    {
        var instance = new MyForm();
        instance.DoLater(1000, x => x.MyFunc());
    }
