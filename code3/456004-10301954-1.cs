    interface IObject<T>
    {
        T prop2 {get;set;}
    }
    class ObjectService<T, Z> where T : IObject<Z>
    {
        public T GetObject(T o)
        {
            return o;
        }
        public void SetValue(T o, Z val)
        {
            o.prop2 = val;
        }
    }
