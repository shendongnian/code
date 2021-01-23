    interface IIndexed { int this[int index] { get; set; } }
    struct StructArray : IIndexed { 
        public int[] Array;
        public int this[int index] {
            get { return Array[index]; }
            set { Array[index] = value; }
        }
    }
    static int Generic<T>(int length, T a, T b) where T : IIndexed {
        int sum = 0;
        for (int i = 0; i < length; i++)
            sum += a[i] * b[i];
        return sum;
    }
    static int Specialized(int length, StructArray a, StructArray b) {
        int sum = 0;
        for (int i = 0; i < length; i++)
            sum += a[i] * b[i];
        return sum;
    }
