    public AMap()
    {
      Id(x => x.AId);
      Map(x => x.Name);
      References<B>(x => x.BObject)
        .Column("BOject_id");
      Map(x => x.BId)
        .Column("BOject_id") // the same column names
        .ReadOnly();
    }
