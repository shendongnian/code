    public static class Factory
    {
        public static A CreateA()
        {
            var a = new A();
            a.Extension = new ExtensionA();
            return a;
        }
        ...
    }
