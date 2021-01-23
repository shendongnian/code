    public IQueryable<AuditRecord> AuditRecords
    {
        get
        {
            MyContext ctx = new MyContext();
            var ars = from ar in ctx.AuditRecords
                      where ar.EntityTable.Equals(this.GetType().Name)
                      select ar;
            return ars;
        }
    }
