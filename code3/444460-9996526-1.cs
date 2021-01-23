        [XmlElement("Test")]
        public List<String> TestList
        {
            get;
            set;
        }
        [XmlIgnore]
        public IList<String> Tests
        {
            get { return TestList; }
        }
