    [XmlIgnore]
    public Texture2D SideSprite { get; set; }
    [XmlElement("SideSprite")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Texture2DProcessor SideSpriteProcessor
    {
        get { return SideSprite; }
        set { SideSprite = value; }
    }
