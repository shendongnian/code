    class ZSliceWrapper<T>
    {
        public T[, ,] Source { get; set; }
        public int ZIndex { get; set; }
        public T this[int xIndex, int yIndex]
        {
            get // you could even implement a set.
            {
                return Source[xIndex, yIndex, ZIndex];
            }
        }
    }
