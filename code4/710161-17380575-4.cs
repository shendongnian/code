    interface ICustom
    {
        int Key { get; set; }
    }
    class Custom : ICustom
    {
        public int Key { get; set; }
        public int Value { get; set; }
    }
    class Another : ICustom
    {
        public int Key { get; set; }
    }
    
    class DicEqualityComparer : IEqualityComparer<ICustom>
    {
        public bool Equals(ICustom x, ICustom y)
        {
            return x.Key == y.Key;
        }
    
        public int GetHashCode(ICustom obj)
        {
            return obj.Key;
        }
    }
