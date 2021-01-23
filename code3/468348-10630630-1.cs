    public static Action<T> SuppressExceptions<T>(Action<T> action)
    {
        return item =>
        {
            try
            {
                action(item);
            }
            catch (Exception e)
            {
                // Log it, presumably
            }
        };
    }
