    public static readonly Genres[] AllGenres = Enum.GetValues(typeof(Genres)).Cast<Genres>().ToArray();
    // sample:
    public void test()
    {
       var first = AllGenres [0];
    }
