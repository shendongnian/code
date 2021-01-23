    public Section()
        : this(new TabCollection(this), new SubSectionCollection(this))
    { }
    public Section(TabCollection tabCollection, IList<ISection> sections)
    {
        _tabs = tabCollection;
        _sections = sections;
    }
