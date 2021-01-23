    class myClass : ICloneable
    {
        public int i;
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
