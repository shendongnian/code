    static void SampleMethod(string arg1)
    {
        ThrowIfNull(() => arg1);
        // continue to other normal stuff here...
    }
    
    public static void ThrowIfNull<T>(Func<T> lambda) 
        where T : class
    {
        if (lambda() == null)
        {
            throw new ArgumentNullException(lambda.Target.GetType().GetFields()[0].Name);
        }
    }
