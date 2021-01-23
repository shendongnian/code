    private static readonly MyData[] RefData = new []
    {
        new MyData(/* whatever */),
        new MyData(/* whatever */),
        new MyData(/* whatever */),
    };
    public ReadOnlyCollection<MyData> ReferenceTable
    {
        get { return new ReadOnlyCollection<MyData>(RefData); }
    }
