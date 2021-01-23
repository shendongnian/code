    interface ISneaky<T>
    {
        T Foo { get; }
    }
    class Sneaky<T> : ISneaky<T>
    {
        T ISneaky<T>.Foo { get { return default(T); } }
    }
    class Program
    {
        static void Main()
        {
            Execute(typeof(int));
        }
        static void Execute(Type t)
        {
            dynamic obj = Activator.CreateInstance(
                typeof(Sneaky<>).MakeGenericType(t));
            // crafy hack to flip from non-generic code into generic code:
            Evil(obj);
        }
        static void Evil<T>(ISneaky<T> sneaky)
        {   // in here, life is simple; no more reflection
            Console.WriteLine("{0}: {1}", typeof(T).Name, sneaky.Foo);
        }
    }
