    public static IList<string> Names { get; private set; }
    public static void UpdateNames() {
        List<string> tmp = SomeSqlQuery();
        Names = tmp.AsReadOnly();
    }
