    public String XmlContent { get; set; }
    
    public XElement XmlValueWrapper
    {
        get { return XElement.Parse(XmlContent); }
        set { XmlContent = value.ToString(); }
    }
    
    public partial class XmlEntityMap : EntityTypeConfiguration<XmlEntity>
    {
        public FilterMap()
        {
            // ...
            this.Property(c => c.XmlContent).HasColumnType("xml");
    
            this.Ignore(c => c.XmlValueWrapper);
        }
    }
