    public static class MaybeDisposer
    {
        static class ClassDisposer<T> where T : class,IDisposable
        {
            public static void Zap(ref T it)
            {
                T old_it = System.Threading.Interlocked.Exchange(ref it, null);
                if (old_it != null)
                {
                    Console.WriteLine("Disposing class {0}", typeof(T));
                    old_it.Dispose();
                }
                else
                    Console.WriteLine("Class ref {0} already null", typeof(T));
            }
        }
        static class StructDisposer<T> where T : struct,IDisposable
        {
            public static void Zap(ref T it)
            { 
                Console.WriteLine("Disposing struct {0}", typeof(T));
                it.Dispose();
                it = default(T);
            }
        }
        static class nonDisposer<T>
        {
            public static void Zap(ref T it)
            {
                Console.WriteLine("Type {0} is not disposable", typeof(T));
                it = default(T);
            }
        }
        class findDisposer<T>
        {
            public static ActByRef<T> Zap = InitZap;
            public static void InitZap(ref T it)
            {
                Type[] types = {typeof(T)};
                Type t;
                if (!(typeof(IDisposable).IsAssignableFrom(typeof(T))))
                    t = typeof(MaybeDisposer.nonDisposer<>).MakeGenericType(types);
                else if (typeof(T).IsValueType)
                    t = typeof(MaybeDisposer.StructDisposer<>).MakeGenericType(types);
                else
                    t = typeof(MaybeDisposer.ClassDisposer<>).MakeGenericType(types);
                Console.WriteLine("Assigning disposer {0}", t);
                Zap = (ActByRef<T>)Delegate.CreateDelegate(typeof(ActByRef<T>), t, "Zap");
                Zap(ref it);
            }
        }
        public static void Zap<T>(ref T it)
        {
            findDisposer<T>.Zap(ref it);
        }
    }
