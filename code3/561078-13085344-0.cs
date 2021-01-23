    internal interface IF1
    {
        void M1();
    }
    internal interface IF1_extension : IF1
    {
    }
    internal interface IF2
    {
        void M2();
    }
    internal class ClassImplementingIF1IF2 : IF1_extension, IF2
    {
        public void M1()
        {
            throw new NotImplementedException();
        }
        public void M2()
        {
            throw new NotImplementedException();
        }
    }
    internal interface Getter<T> where T : class
    {
        T Get();
    }
    internal class Holder<T1, T2> //: Getter<T1>, Getter<T2> // not possible since T1 and T2 may be the same => won't compile!
        where T1 : class
        where T2 : class
    {
        private Holder(T1 t1, T2 t2)
        {
            Debug.Assert(t1 != null, "Argument is no " + typeof(T1).Name);
            Debug.Assert(t2 != null, "Argument is no " + typeof(T2).Name);
            this.t1 = t1;
            this.t2 = t2;
        }
        public static Holder<T1, T2> CreateFrom<T>(T t) where T : T1, T2
        {
            return new Holder<T1, T2>(t, t);
        }
        public static Holder<T1, T2> CreateDynamicallyFrom(object t)
        {
            return new Holder<T1, T2>(t as T1, t as T2);
        }
        public readonly T1 t1;
        public readonly T2 t2;
        //T1 Getter<T1>.Get()
        //{
        //    return t1;
        //}
        //T2 Getter<T2>.Get()
        //{
        //    return t2;
        //}
    }
    
    internal class Holder<T1, T2, T3>  // Holder<T1,T2,T3,T4> etc. are defined in a similar way
        where T1 : class
        where T2 : class
        where T3 : class
    {
        private Holder(T1 t1, T2 t2, T3 t3)
        {
            Debug.Assert(t1 != null, "Argument is no " + typeof(T1).Name);
            Debug.Assert(t2 != null, "Argument is no " + typeof(T2).Name);
            Debug.Assert(t3 != null, "Argument is no " + typeof(T3).Name);
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
        }
        public static Holder<T1, T2,T3> CreateFrom<T>(T t) where T : T1, T2, T3
        {
            return new Holder<T1, T2, T3>(t, t, t);
        }
        public static Holder<T1, T2, T3> CreateDynamicallyFrom(object t)
        {
            return new Holder<T1, T2, T3>(t as T1, t as T2, t as T3);
        }
        public readonly T1 t1;
        public readonly T2 t2;
        public readonly T3 t3;
    }
    
    internal static class Test
    {
        public static void doIt<T>(T t) where T : IF1, IF2
        {
            t.M1();
            t.M2();
        }
        public static void doIt(Holder<IF1, IF2> t) // Interfaces should be mentioned in alpahbetical order since Holder<IF1,IF2> != Holder<IF2,IF1>
        {
            t.t1.M1();
            t.t2.M2();
        }
        public static void doIt_extended<T1, T2>(Holder<T1, T2> t) // handles conversions from Holder<T1,T2> to Holder<T1 or base of T1, T2 or base of T2>
            where T1 : class, IF1
            where T2 : class, IF2
        {
            t.t1.M1();
            t.t2.M2();
        }
        public static void test()
        {
            var c = new ClassImplementingIF1IF2();
            doIt(c);
            var c_holder = Holder<IF1, IF2>.CreateFrom(c);
            doIt(c_holder);
            var another_c_holder = Holder<IF1_extension, IF2>.CreateFrom(c);
            doIt_extended(another_c_holder);
            object diguised_c = c;
            var disguised_c_holder = Holder<IF1, IF2>.CreateDynamicallyFrom(diguised_c);
            doIt(disguised_c_holder);
        }
    }
