    public SiteMapNode : IHierarchy<SiteMapNode> // Implies IHierarchy
    {
        private SiteMapNode _Parent;
        private IList<SiteMapNode> _Children;
        // Implicit implement of IHierarchyItem and members of SiteMapNode itself.
        int Id { get; set; }
        string Title { get; set; } 
        // Implicit implementation of IHierarchy<SiteMapNode> members
        // These are also members of SiteMapNode itself.
        SiteMapNode Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
        IList<SiteMapNode> Children
        {
            get return _Children;
            set _Children = value;
        }
        // Explicit implementation of IHierarchy members
        // The interface prefix is required to distinguish these from the
        // type-specific members above to declare different return types.
        IHierarchy IHierarchy.Parent
        {
            get { return _Parent; } // Might need (IHierarchy) cast
            set { Parent = (SiteMapNode)value; }
        }
        IList<IHierarchy> IHierarchy.Children
        {
            get { return _Children; } // Might need (IList<IHierarchy>) cast
            set { _Children = (IList<SiteMapNode>)value; }
        }
    }
