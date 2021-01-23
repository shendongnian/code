    interface IObjectWithId<T>
    {
        T Id { get; }
    }
    
    class IdEqualityComparer<T, TId> : EqualityComparer<T>
        where T : IObjectWithId<TId>
    {
        public override bool Equals(T x, T y)
        {
            return EqualityComparer<TId>.Default.Equals(x.Id, y.Id);
        }
    
        public override int GetHashCode(T obj)
        {
            return EqualityComparer<TId>.Default.GetHashCode(obj.Id);
        }
    }
    
    class A : IObjectWithId<string>
    {
        public string Id { get; set; }
    }
