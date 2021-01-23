    struct Item1 { public double Foo { get; set; } }
    struct Item2 { public double Foo { get; set; } }
    class Program
    {
        static void Main(string[] args)
        {
            Item1 i1 = new Item1();
            CopyDynamically(new Item2 { Foo = 42 }, ref i1);
            Console.WriteLine(i1.Foo);
            i1 = CopyDynamically<Item1>(new Item2 { Foo = 3.14 });
            Console.WriteLine(i1.Foo);
        }
        static void CopyDynamically<T>(object source, ref T target)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (target == null)
                throw new ArgumentNullException("target");
            
            foreach (PropertyInfo pi in source.GetType().GetProperties())
            {
                PropertyInfo targetPi = typeof(T).GetProperty(pi.Name);
                
                if (targetPi != null && targetPi.SetMethod != null && targetPi.SetMethod.IsPublic)
                {
                    object val = pi.GetValue(source, null);
                    object o = target;
                    
                    try { targetPi.SetValue(o, val, null); }
                    catch { }
                    target = (T)o;
                }
            }
        }
        static T CopyDynamically<T>(object source, params object[] ctorArgs)
        {
            T target = (T)Activator.CreateInstance(typeof(T), ctorArgs);
            CopyDynamically(source, ref target);
            return target;
        }
    }
