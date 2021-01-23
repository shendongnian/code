    class PageElements
    {
        public virtual int PageNumber { get; set; }
        
        public virtual IList<BookElements> { get; set; }
    }
    class PageElementsMap : ClassMap<PageElements>
    {
        public PageElementsMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.PageNumber);
            
            HasMany(x => x.BookElements)
                .KeyColumn("PageElementsID")
                .Cascade.AllDeleteOrphan();
        }
    }
    public virtual IDictionary<int,PageElements> PageElements { get; set; }
    class MainEntityMap : ClassMap<MainEntity>
    {
        public MainEntityMap()
        {
            
            ...
            
            HasMany( x => x.PageElements )
                .AsMap( x=> x.PageNumber )
                .Cascade.AllDeleteOrphan();
            ...
        }
    }
