    class Test : ICloneable
    {
        public int A { get; set; }
        public int B { get; set; }
        #region ICloneable-Member
        public object Clone()
        {
            return base.MemberwiseClone();
        }
        #endregion
    }
