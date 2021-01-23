    class MyEntity
    {
        public virtual PropertyType Property
        {
            get
            {
                EnsureOther();
                return Other.Property;
            }
            set
            {
                EnsureOther();
                other.Property = value;
            }
        }
        void EnsureOther()
        {
            if (Other == null)
                Other = new Other();
        }
        public virtual Other { get; set; }
    }
    class Other
    {
        public virtual PropertyType Property { get; set; }
    }
