    public static string MyExtensionProperty(this targetClass)
    {
        set { var doSomething = value; }
        get { return "Here's the result!"; }
    }
