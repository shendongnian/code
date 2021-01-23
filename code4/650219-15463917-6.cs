    public class Matrix<T>
    {
        private T[, ,] _array;
        public Matrix(int sizeX, int sizeY, int sizeZ)
        {
            _array = new T[sizeX, sizeY, sizeZ];
        }
        public T this[int i, int j, int k]
        {
            get { return _array[i, j, k]; }
            set { _array[i, j, k] = value; }
        }
        public int CurrentI { get; set; }
        public int CurrentJ { get; set; }
        public int CurrentK { get; set; }
        public void SetCurrentCell(int i, int j, int k)
        {
            CurrentI = i;
            CurrentJ = j;
            CurrentK = k;
        }
        public T Current
        {
            get { return _array[CurrentI, CurrentJ, CurrentK]; }
            set { _array[CurrentI, CurrentJ, CurrentK] = value; }
        }
        public static implicit operator T(Matrix<T> matrix)
        {
            return matrix.Current;
        }
        // The assignment operator (=) cannot be overloaded. But we can overload |
        // instead, allowing us to write: m |= value in order to perform an assignment.
        public static Matrix<T> operator |(Matrix<T> m, T value)
        {
            m.Current = value;
            return m;
        }
    }
