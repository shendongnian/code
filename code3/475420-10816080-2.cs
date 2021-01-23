    public static T GetValueOrNull<T>(Func<T> valueProvider) 
        where T : class
    {
        try
        {
            return valueProvider();
        }
        catch (NullReferenceException)
        {
            return null;
        }
    }
