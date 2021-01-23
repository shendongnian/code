    public static Action<T> ActionAndCatch<T>(Action<T> action, Action<Exception> catchAction)
    {
        return item =>
        {
            try { action(item); }
            catch (System.Exception e) { catchAction(e); }
        };
    }
