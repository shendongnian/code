    public SqlCeDB(string filename, Dictionary<string, string> options)
        : this(new Dictionary<string, string>(options) {
                   { "DataSource", filename }
               })
    {
    }
