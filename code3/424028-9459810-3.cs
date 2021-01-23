    class DualKey<T> : IEquatable<DualKey<T>> where T : IEquatable<T>
    {
        public T Key0 { get; set; }
        public T Key1 { get; set; }
    
        public DualKey(T key0, T key1)
        {
            Key0 = key0;
            Key1 = key1;
        }
        public override int GetHashCode()
        {
            return Key0.GetHashCode() ^ Key1.GetHashCode();
        }
    
        public bool Equals(DualKey<T> obj)
        {
            return (this.Key0.Equals(obj.Key0) && this.Key1.Equals(obj.Key1))
                || (this.Key0.Equals(obj.Key1) && this.Key0.Equals(obj.Key0));
        }
    }
