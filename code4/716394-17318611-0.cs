    #if NET2
    public static void MyExtensionMethod(string self)
    #else
    public static void MyExtensionMethod(this string self)
    #endif
    {
        // ...
