    public class TestClass
    {
        private ConvertElement _convertElement;
        [XmlElement("ConvertElement", typeof(ConvertElement))]
        public ConvertElement ConvertElement
        {
            get { return _convertElement; }
            set { _convertElement = value; }
        }
    }
