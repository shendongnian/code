    /// <summary>
    /// Computes a permutation of ... 
    /// </summary>
    class Permutation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Permutation"/> class.
        /// </summary>
        public Permutation()
        {
            Permutations = new List<long>(20); // you can set here your capacity.
        }
        /// <summary>
        /// Builds permutations of a byte array.
        /// </summary>
        /// <param name="digits">The digits</param>
        /// <param name="n">The n</param>
        /// <param name="i">The i</param>
        public void DoPermute(ref byte[] digits, ref int n, ref int i)
        {
            if (i == n)
            {
                long temp = Numbers.JoinDigits(digits);
                Permutations.Add(temp);
            }
            else
            {
                for (int j = i; j < n; j++)
                {
                    SwapValues(ref digits, ref i, ref j);
                    int temp = i + 1;
                    DoPermute(ref digits, ref n, ref temp);
                    SwapValues(ref digits, ref i, ref j);
                }
            }
        }
        /// <summary>
        /// Gets the permuation result.
        /// </summary>
        public List<long> Permutations { get; private set; }
    }
