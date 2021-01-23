    public void Override(AutoMapping<Record> mapping)
        {
            mapping.Id(x => x.Id).Column("RecordId");
            mapping.Map(x => x.Name).Not.Nullable();
            mapping.References(x => x.Parent).Not.Nullable().Column("ParentRecordId");
            mapping.References(x => x.Type).Not.Nullable().Column("TypeId");
        }
 
