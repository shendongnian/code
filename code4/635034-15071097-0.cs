namespace DatabaseModel
{
    [Description("Represents the selected nodes in the Coverage pane")]
    [Serializable()]
    [XmlRootAttribute("XmlCoverage", Namespace = "GISManager", IsNullable = false)]
    public class TXmlCoverage : IXmlPolygon
    {
        [XmlArray(ElementName = "sbets"), XmlArrayItem(ElementName = "sbet")]
        public List<String> SbetsSelected { get; set; }
        [XmlArray(ElementName = "sdcs"), XmlArrayItem(ElementName = "sdc")]
        public List<String> SdcsSelected { get; set; }
        [XmlElementAttribute(ElementName = "area")]
        public Boolean IsAreaSelected { get; set; }
        [XmlElementAttribute(ElementName = "fpath")]
        public Boolean IsFlightPathSelected { get; set; }
        [XmlElementAttribute(ElementName = "fpoly")]
        public Boolean IsFlightPolySelected { get; set; }
        [XmlElementAttribute(ElementName = "mpoly")]
        public Boolean IsMinePolySelected { get; set; }
        [XmlElementAttribute(ElementName = "bldg")]
        public Boolean IsBuildingsSelected { get; set; }
        [XmlElementAttribute(ElementName = "hgt")]
        public Boolean IsHeightSelected { get; set; }
        [XmlIgnore()]
        public Boolean ArePolygonsSelected { get { return IsMinePolySelected && IsBuildingsSelected && IsHeightSelected; } }
        public TXmlCoverage()
        {
            SbetsSelected = new List<String>();
            SdcsSelected = new List<String>();
            IsAreaSelected = false;
            IsFlightPathSelected = false;
            IsFlightPolySelected = false;
        }
    }
}</pre>
