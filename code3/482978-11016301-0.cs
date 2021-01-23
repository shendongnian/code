    using(Entities entities = new Entities())
    {
        Table1 table = entities.Table1.FirstOrDefault();
        table.Table2.CreateSourceQuery().Include("Table3")
            .Execute(MergeOption.AppendOnly);
    }
