    public static class Factory3
    {
        public static Factory<T1> CreateFactory<T1>(I<T1> o)
        {
            return new Factory<T1>();
        }
    }
    public class Factory<T1>
    {
        public Tuple<T, Other<T1>> Create<T>(T o) where T : I<T1>
        {
            return new Tuple<T, Other<T1>>(o, o.CreateOther());
        }
    }
