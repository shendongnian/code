        [XmlAttribute(AttributeName = "action")]
        public EAction Action
        {
            get;
            set;
        }
        public bool ShouldSerializeAction()
        {
            return this.Action != EAction.None;
        }
