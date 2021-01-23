    [Serializable()]
    public partial class Areas
    {
        [XmlArrayItem("Property", typeof(AreasAreaProperty))]
        public AreasAreaProperty[][] Area { get; set; }
