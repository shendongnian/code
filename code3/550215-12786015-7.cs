    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class items
    {
        [XmlElementAttribute("item")]
        public itemsItem[] item { get; set; }
    }
