    [Serializable]
    [DesignerCategory("code")]
    [XmlType(Namespace = Namespace3)]
    [XmlRoot(Namespace = Namespace3, IsNullable = true)]
    public partial class rootElem
    {
        private const string Namespace3 = "namespace3"; // to avoid repetition
        [XmlElement(Namespace = Namespace3)]
        public int Prop1 { get; set; }
    }
