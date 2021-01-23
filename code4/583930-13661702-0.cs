    class ResultSet : IResultSet
    {
      public ResultSet(inject all property values here) {}
      public TypeA A { get; private set; }
      public TypeB B { get; private set; }
      public TypeC C { get; private set; }
      public TypeD D { get; private set; }
      public TypeL L { get; private set; }
    }
    IEnumerable<IResultSet> sets =
        from a in patient
        from b in patient
        from c in patient
        from d in patient
        from l in patient
        where a.VisitNum < b.VisitNum 
              && b.VisitNum < c.VisitNum 
              && c.VisitNum < d.VisitNum 
              && d.VisitNum < l.VisitNum
        select new ResultSet(a, b, c, d, l);
