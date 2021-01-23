    public static class Pinboard
    {
        public static Pinboard<T1, T2, T3> Create(IPosterGenerator<T1> generator1,
                                                  IPosterGenerator<T2> generator2,
                                                  IPosterGenerator<T3> generator3)
        {
            return new Pinboard<T1, T2, T3>(generator1, generator2, generator3);
        }
    }
