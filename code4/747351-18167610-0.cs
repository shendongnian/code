    public static class GlobalExtensions
    {
    
        public static int SizeOf<T>()
        {
            return SizeOf(typeof (T));
        }
    
        public static int SizeOf(this Type type)
        {
            var dynamicMethod = new DynamicMethod("SizeOf", typeof(int), Type.EmptyTypes);
            var generator = dynamicMethod.GetILGenerator();
    
            generator.Emit(OpCodes.Sizeof, type);
            generator.Emit(OpCodes.Ret);
    
            var function = (Func<int>) dynamicMethod.CreateDelegate(typeof(Func<int>));
            return function();
        }
    }
