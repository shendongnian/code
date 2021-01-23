        [XmlAttribute]
        public bool someBool { get; set; }
        [XmlIgnore]
        public bool someBoolSpecified { get; set; }
        [XmlIgnore]
        public bool? SomeBool
        {
            get
            {
                return someBoolSpecified ? someBool : default(bool?);
            }
            set
            {
                someBoolSpecified = value != default(bool?);
                someBool = value ?? default(bool);
            }
        }
