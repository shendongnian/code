    public class WorkMap : ClassMap<WorkEntity>
    {
        public WorkMap()
        {
            Id(x => x.WorkId).Column("ID_ZLECENIE").GeneratedBy.Sequence("SEQ_TAE_ZLECENIE");
            HasOne(x => x.OrderExtension)
                .Cascade.All();
         }
    }
    
    public class OrderExtensionMap : ClassMap<OrderExtensionEntity>
    {
        public OrderExtensionMap()
        {
            LazyLoad();
    
            Id(x => x.Id).Column("ID_ZLECENIE").GeneratedBy.Foreign("Work");
            HasOne(x => x.Work).Constrained();
            HasMany(x => x.IssueInformation).KeyColumn("FK_ZLECENIE");
        }
    }
