    class A {
        public abstract int ListCount { get; }
    }
    
    class B : A {
        protected List<object> BList = new List<object>();
        public override int ListCount {
            get {
                return BList.Count;
            }
        }
    }
