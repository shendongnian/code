    class X
    {
        public int ID { get; set; }
    
        public override bool Equals(object obj)
        {
            X x = obj as X;
            if (x == null)
                return false;
            return x.ID == ID;
        }
    
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
