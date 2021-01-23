        [XmlElementAttribute("ValidThrough", DataType = "duration")]
        [DataMember(Name = "ValidThrough")]
        [DefaultValue("P10D")]
        public string ValidThrough
        {
            get
            {
                return XmlConvert.ToString(_validThroughField);
            }
            set
            {
                _validThroughField= XmlConvert.ToTimeSpan(value);
            }
        }
        [XmlIgnore]
        public TimeSpan _validThroughField { get; set; }
