    public class B
    {
        public virtual A A { get; set; }
        public virtual C C { get; set; }
        public virtual string Field1 {get; set; }
        public virtual string Field2 {get; set; }
    }
    public class BMap : ClassMap<B>
    {
        public BMap()
        {
            Table("B");
            CompositeId()
                .KeyReference(x => x.A, "AID", "Date")
                .KeyReference(x => x.C, "CID");
            Map(x => x.Field1, "Field1").Not.Nullable();
            Map(x => x.Field2, "Field2").Not.Nullable();
        }
    }
    // query for it
    
    var results = session.CreateCritera<B>()
        .JoinAlias("A", "a")
        .JoinAlias("C", "c")
        .SetProjection(Projections.List()
            .Add(Projections.Property("Field1"), "Field1")
            .Add(Projections.Property("Field2"), "Field2")
            .Add(Projections.Property("a.CreatedDate"), "Date")
            .Add(Projections.Property("c.Name"), "CName"))
        .SetResulttransformer(Transformers.AliasToBean<YourDto>())
        .List<YourDto>();
