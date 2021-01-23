    class MultiD<T> {
        private readonly T[] data;
        private readonly int[] mul;
        public MultiD(int[] dim) {
            // Add some validation here:
            // - Make sure dim has at least one dimension
            // - Make sure that all dim's elements are positive
            var size = dim.Aggregate(1, (p, v) => p * v);
            data = new T[size];
            mul = new int[dim.Length];
            mul[0] = 1;
            for (int i = 1; i < mul.Length; i++) {
                mul[i] = mul[i - 1] * dim[i - 1];
            }
        }
        private int GetIndex(IEnumerable<int> ind) {
            return ind.Zip(mul, (a, b) => a*b).Sum();
        }
        public T this[int[] index] {
            get { return data[GetIndex(index)]; }
            set { data[GetIndex(index)] = value; }
        }
    }
