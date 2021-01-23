    [XmlRoot(ElementName="request")]
    public class Request
    {
        #region Attributes
        [XmlAttribute(AttributeName = "version")]
        public string Version
        {
            get
            {
                return "1.0";
            }
            set{}
        }
        [XmlAttribute(AttributeName = "action")]
        public EAction Action
        {
            get;
            set;
        }
        #endregion
