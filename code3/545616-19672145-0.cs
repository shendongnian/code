    class AlwaysEquals
    {
        override public bool Equals(Object o)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return 1;
        }
    }
