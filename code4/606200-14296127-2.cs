    /// <summary>
    /// Initializes a new instance of the <see cref="MersenneTwister"/> class.
    /// </summary>
    /// <param name="seed">The NONZERO seed.</param>
    public MersenneTwister( uint seed )
    {
        /* Setting initial seeds to mt[N] using the generator Line 25 of Table 1 in [KNUTH 1981, The Art of Computer Programming Vol. 2 (2nd Ed.), pp102] */
        mt[0] = seed & 0xffffffffU;
        for ( mti = 1; mti < N; ++mti )
        {
            mt[mti] = ( 69069 * mt[mti - 1] ) & 0xffffffffU;
        }
    }
