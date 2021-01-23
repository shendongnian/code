    public class ApproximateFloatComparer : IComparer<float>
    {
        public float Range { get; set; }
        public ApproximateFloatComparer(float range)
        {
            this.Range = range;
        }
        public int Compare(float x, float y)
        {
            if (x - this.Range < y && x + this.Range > y)
                return 0;
            else return x.CompareTo(y);
        }
    }
