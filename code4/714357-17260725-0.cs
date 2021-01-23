    class Player {
        ...
        public int val0, val1, val2, val3, val4, val5, val6;
        public IEnumerable<int> Numbers {
            get {
                return new[] {val0, val1, val2, val3, val4, val5, val6};
            }
        }
    }
