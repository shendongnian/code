    // this will not work!
    public static class MyExtensionsClass
    {
        static string MyToLowerExtension(this string str)
        {
            return str.ToLower();
        }
    }
