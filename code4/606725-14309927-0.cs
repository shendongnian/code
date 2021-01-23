    [Flags]
    enum Numbers
    {
        One = 1,
        Two = 2,
        Three = 2 << 1,
        Four = 2 << 2,
        Five = 2 << 3,
        Six = 2 << 4
    }
    //You don't need to hardcode it, you can fill it at runtime.
    readonly Dictionary<int, Numbers> _dictionary = new Dictionary<int, Numbers>
    {
        {1, Numbers.One},
        {2, Numbers.Two},
        {3, Numbers.Three},
        {4, Numbers.Four},
        {5, Numbers.Five},
        {6, Numbers.Six},
    };
    int GetFlags(params int[] ints)
    {
        //Do checks on the dictionary, etc.
        return ints.Aggregate(0, (current, i) => current | (int) _dictionary[i]);
    }
