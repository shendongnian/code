        [XmlElement("IntField")]
        [Browsable(false)] // not displayed in grids
        [EditorBrowsable(EditorBrowsableState.Never)] // not displayed by intellisense
        public string IntFieldString
        {
            get
            {
                return DoSomeConvert(IntField);
            }
            set
            {
                IntField = DoSomeOtherConvert(value);
            }
        }
        [XmlIgnore]
        public int? IntField { get; set; }
