    [XmlIgnore]
    public Category? Category { get; set; }
    [XmlAttribute("Category")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public Category CategorySerialized
    {
        get { return Category.Value; }
        set { Category = value; }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public bool ShouldSerializeCategorySerialized()
    {
        return Category.HasValue;
    }
