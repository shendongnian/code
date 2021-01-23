    public AMap()
    {
      /* mapping for id and properties here */
      HasOne(x => x.child)
          .Cascade.All();
    }
    public BMap()
    {
      /* mapping for id and properties here */
      References(x => x.parent)
          .Unique();
    }
