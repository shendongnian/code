    public static class Class
    {
        public static void ClassMethod()
        {
            SharedMethod<object>();
        }
        static void SharedMethod<T>()
        {
            //----
        }
        public static void GenericClassMethod<T>()
        {
            return GenericClass<T>.SharedMethod();
        }
        static class GenericClass<T> 
        {
            static void SharedMethod()
            {
                //available here since private members of outer class is visible to nested class
                SharedMethod<T>();
            }
        }
    }
