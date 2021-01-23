    class Program
    {
        public static void Main(string[] args)
        {
            Item1 i1 = CopyDynamically<Item1>(new Item2 { Foo = 42 });
            Console.WriteLine("Item1: {0}", i1.Foo);
        }
        static T CopyDynamically<T>(object source, params object[] ctorArgs)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            object target = Activator.CreateInstance(typeof(T), ctorArgs);
            
            foreach (PropertyInfo pi in source.GetType().GetProperties())
            {
                PropertyInfo targetPi = typeof(T).GetProperty(pi.Name);
                if (targetPi != null && targetPi.SetMethod != null && targetPi.SetMethod.IsPublic)
                {
                    object piValue = pi.GetValue(source, null);
                    try { targetPi.SetValue(target, piValue, null); }
                    catch { }
                }
            }
            return (T)target;
        }
    }
    class Item1 { public int Foo { get; set; } }
    class Item2 { public int Foo { get; set; } }
