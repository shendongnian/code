    Table("MyClass");
    Id(x => x.Id).GeneratedBy.Identity();
    Map(x => x.Type).CustomType(typeof(Enumerations.MyType));
    public virtual int Id { get; set; }
    public virtual Enumerations.MyType Type { get; set; }
