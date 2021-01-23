    // Test code first
    class Program
    {
        static void Main(string[] args)
        {
            /* 3 pages, of a 4x2 matrix
             * 
             *         |16 17|
             *      | 8  9|19|
             *   | 0  1|11|21|
             *   | 2  3|13|23|
             *   | 4  5|15|
             *   | 6  7|
             *   
             *  shown above are the sequential indeces for a rank 3 array
             */
            SeqArray<double> arr = new SeqArray<double>(3, 4, 2);
            // Initialize values to squential index "num"
            int num = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        arr[i, j, k] = num++;
                    }
                }
            }
            // Check that the array values correspond to the index sequence
            num = 0;
            for (int i = 0; i < 3 * 4 * 2; i++)
            {
                Trace.Assert(arr.InnerArray[i] == num++);
            }
            // Initialize with value=π
            arr = new SeqArray<double>(Math.PI, 4, 5, 6);
        }
    }
    public class SeqArray<T>
    {
        T[] values;
        int[] lengths;
        public SeqArray(params int[] lengths)
        {
            this.lengths = lengths;
            int N = 1;
            for (int i = 0; i < lengths.Length; i++)
            {
                N *= lengths[i];
            }
            values = new T[N];
        }
        public SeqArray(T value, params int[] lengths) : this(lengths)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = value;
            }            
        }
        public int[] Lengths { get { return lengths; } }
        public int Size { get { return values.Length; } }
        internal T[] InnerArray { get { return values; } }
        public int Que(params int[] indeces)
        {
            // Check if indeces are omited like arr[4] instead of arr[4,0,0]
            if (indeces.Length < lengths.Length)
            {
                // Make a new index array padded with zeros
                int[] temp = new int[lengths.Length];
                indeces.CopyTo(temp, 0);
                indeces = temp;
            }
            // Count the elements for indeces
            int k = 0;
            for (int i = 0; i < indeces.Length; i++)
            {
                k = lengths[i] * k + indeces[i];
            }
            return k;
        }
        public T this[params int[] indeces]
        {
            get { return values[Que(indeces)]; }
            set { values[Que(indeces)] = value; }
        }
    }
