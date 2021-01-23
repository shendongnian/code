    public class WikiPage
    {
        public virtual int Id { get; protected set; }
        public virtual IEnumerable<WikiPage> BackReferences { get; }
        public virtual IEnumerable<WikiPage> References { get; }
    }
    
    // WikiPageMap : ClassMap<WikiPage>
    public WikiPageMap()
    {
        ...
        HasManyToMany(wp => wp.References)
            .Table("WikiPageLinks")
            .ParentKeyColumn("parent_page_id")
            .ChildKeyColumn("referenced_page_id");
    
        HasManyToMany(wp => wp.BackReferences)
            .Table("WikiPageLinks")
            .ParentKeyColumn("referenced_page_id")
            .ChildKeyColumn("parent_page_id")
            .Inverse();
    
        ...
    }
