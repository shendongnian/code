    public static MyGenericClassExtensions
    {
        public static void DoSomething<T, T1>(this MyGenericClass<T> @this,
                                              List<T1> things)
            where T : T1
        {
            ...
        }
    }
