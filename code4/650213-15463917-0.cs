    public class Matrix
    {
        private int[, ,] _array;
        public Matrix(int sizeX, int sizeY, int sizeZ)
        {
            _array = new int[sizeX, sizeY, sizeZ];
        }
        public int this[int i, int j, int k]
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
        public int Current
        {
            get { return _array[CurrentI, CurrentJ, CurrentK]; }
            set { _array[CurrentI, CurrentJ, CurrentK] = value; }
        }
        public static implicit operator int(Matrix matrix)
        {
            return matrix.Current;
        }
    }
