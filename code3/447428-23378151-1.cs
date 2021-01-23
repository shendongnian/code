    /// <summary>
    /// This class is a drop-in replacement to use instead of Random(). Its
    /// main purpose is to work identically across multiple platforms for a given
    /// seed value - whereas the Random class is not guaranteed to give the
    /// same results on different platforms even when the seed is the same.
    /// 
    /// This is an implementation of a Linear Congruential Generator which is
    /// a very simple pseudorandom number generator. It is used instead of Random()
    /// since Random() is implemented differently in Mono than .NET (and even
    /// between different major-versions of .NET).
    /// 
    /// This is NOT recommended to be used for anything that should be secure such
    /// as generating passwords or secret tokens. A "cryptogrpahically secure pseudorandom
    /// number generator" (such as Mersenne Twister) should be used for that, instead.
    /// 
    /// More about Linear Congruential Generators can be found here:
    /// http://en.wikipedia.org/wiki/Linear_congruential_generator
    /// </summary>
    public class CrossPlatformRandom : Random
    {
        // To start with, we'll be using the same values as Borland Delphi, Visual Pascal, etc.
        // http://en.wikipedia.org/wiki/Linear_congruential_generator#Parameters_in_common_use
        private const int LCG_MULTIPLIER = 134775813; // 0x08088405
        private const int LCG_INCREMENT = 1;
        private int _seed;
        /// <summary>
        /// Initializes a new instance of the CrossPlatformRandom class, using a time-dependent
        /// default seed value.
        /// 
        /// Please note that this values generated from this are NOT guaranteed to be the same
        /// cross-platform because there is no seed value. In cases where the caller requires
        /// predictable or repeatable results, they MUST specify the seed.
        /// </summary>
        public CrossPlatformRandom()
        {
            // System.Random is time-dependent, so we will just use its first number to generate
            // the seed.
            Random rand = new Random();
            this._seed = rand.Next();
        }
        /// <summary>
        /// Initializes a new instance of the System.Random class, using the specified seed value.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. If a negative number is specified, the absolute value of the number is used.</param>
        public CrossPlatformRandom(int seed)
        {
            _seed = seed;
        }
        private int GetNext() // note: returns negative numbers too
        {
            _seed = (_seed * LCG_MULTIPLIER) + LCG_INCREMENT;
            return _seed;
        }
        /// <summary>
        //  Returns a nonnegative random number.
        /// </summary>
        /// <returns>A 32-bit signed integer greater than or equal to zero and less than System.Int32.MaxValue.</returns>
        public override int Next()
        {
            return this.Next(int.MaxValue);
        }
        /// <summary>
        /// Returns a nonnegative random number less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to zero.</param>
        /// <returns> A 32-bit signed integer greater than or equal to zero, and less than maxValue; that is, the range of return values ordinarily includes zero but not maxValue. However, if maxValue equals zero, maxValue is returned.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">maxValue is less than zero.</exception>
        public override int Next(int maxValue)
        {
            if (maxValue < 0)
            {
                throw new System.ArgumentOutOfRangeException("maxValue is less than zero.");
            }
            ulong result = (ulong)(uint)GetNext() * (ulong)(uint)maxValue;
            return (int)(result >> 32);
        }
        /// <summary>
        /// Returns a random number within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">minValue is greater than maxValue.</exception>
        public override int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new System.ArgumentOutOfRangeException("minValue is greater than maxValue.");
            }
            return minValue + this.Next(maxValue - minValue);
        }
        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers.</param>
        /// <exception cref="System.ArgumentNullException">buffer is null.</exception>
        public override void NextBytes(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new System.ArgumentNullException("buffer is null.");
            }
            for (int index = 0; index < buffer.Length; index++)
            {
                buffer[index] = (byte)this.Next((int)byte.MaxValue);
            }
        }
        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        /// <returns>A double-precision floating point number greater than or equal to 0.0, and less than 1.0.</returns>
        public override double NextDouble()
        {
            return this.Sample();
        }
        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// 
        /// Since System.Random no longer uses this as the basis for all of the other random methods,
        /// this method isn't used widely by this class. It's here for completeness, primarily in case Random
        /// adds new entry points and we are lucky enough that they base them on .Sample() or one of the other existing methods.
        /// </summary>
        /// <returns>A double-precision floating point number greater than or equal to 0.0, and less than 1.0.</returns>
        protected override double Sample()
        {
            return ((double)this.Next() / (double)int.MaxValue);
        }
    }
