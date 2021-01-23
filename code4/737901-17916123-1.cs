    public class EPubBody
    {
        [XmlElement("image", typeof(EPubImage))]
        public object[] BodyItems;
    }
