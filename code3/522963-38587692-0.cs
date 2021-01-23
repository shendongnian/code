    static void SampleMethod(string arg1)
    {
        ThrowIfNull(() => arg1);
        // continue the normal stuff here...
    }
    
    public static void ThrowIfNull&lt;T&gt;(this Func&lt;T&gt; lambda) 
        where T : class
    {
        if (lambda() == null)
        {
            throw new ArgumentNullException(lambda.Target.GetType().GetFields()[0].Name);
        }
    }
