    class ReadDbBools : Tuple<Func<DBType, bool?>, string>
    {
        public ReadDbBools(Func<DBType, bool?> retrieveFunc, string ifTrue) : base(retrieveFunc, ifTrue) { }
    }
    static readonly List<ReadDbBools> pairs = new List<ReadDbBools>
    {
        new ReadDbBools(d => d.DbColumn_1, "thing 1"),
        new ReadDbBools(d => d.DbColumn_2, "thing 2")
        //...other columns
    };
