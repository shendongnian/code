    private IList<OrderLine> orderLines;
    public virtual IEnumerable<OrderLine> OrderLines 
    { 
        get { return orderLines.Select(x => x); } 
    }
    HasMany(x => x.OrderLines)
                .Access.CamelCaseField()
                .KeyColumn("ORDER_ID")
                .Inverse()
                .Cascade.AllDeleteOrphan();
