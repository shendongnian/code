    public static class AttachedDecorator
    {
        private class Properties
        {
            public int MyDecoratorProperty1 { get; set; }
            public int MyDecoratorProperty2 { get; set; }
        }
        private static Dictionary<object, Properties> map = new Dictionary<object, Properties>();
        public static int GetMyDecoratorProperty1(object obj)
        {
            Properties props;
            if (map.TryGetValue(obj, out props))
            {
                return props.MyDecoratorProperty1;
            }
            return -1; // or some value that makes sense if the object has no decorated property set
        }
        public static int GetMyDecoratorProperty2(object obj) { /* ... */ }
        public static void SetMyDecoratorProperty1(object obj, int value)
        {
            Properties props;
            if (!map.TryGetValue(obj, out props))
            {
                props = new Properties();
                map.Add(obj, props);
            }
            props.MyDecoratorProperty1 = value;
        }
        public static void SetMyDecoratorProperty2(object obj, int value) { /* ... */ }
    }
    public static class DecoratorExtensions
    {
        private static int GetMyDecoratorProperty1(this object obj)
        {
            return AttachedDecorator.GetMyDecoratorProperty1(obj);
        }
        private static void SetMyDecoratorProperty1(this object obj, int value)
        {
            return AttachedDecorator.GetMyDecoratorProperty1(obj, value);
        }
        // ...
    }
