    public static class ExtensionUtils
    {
        public static ExtensionA GetExtension(this A a)
        {
           return a.Extension as ExtensionA;
        }
        ...
    }
