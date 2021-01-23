    class Converter<E> where E : class
    {
        public E Make(object o)
        {
            return o as E;
        }
    }
----------
    public bool IsType(object o, Type t)
    {
        return (o != null) ? t.IsAssignableFrom(o.GetType()) : t.IsClass;
    }
