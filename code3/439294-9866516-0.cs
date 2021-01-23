    public unsafe class UnsafeArray
    {
        private readonly int* _start;
        public readonly int Length;
        public UnsafeArray(int* start, int enforceLength = 0)
        {
            this._start = start;
            this.Length = enforceLength > 0 ? enforceLength : int.MaxValue;
        }
        public int this[int index]
        {
            get { return _start[index]; }
            set
            {
                if (index >= this.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                _start[index] = value;
            }
        }
    }
