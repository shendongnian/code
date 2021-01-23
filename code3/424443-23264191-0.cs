    ...
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        public System.DateTime BirthDate
        {
            get
            {
                return this.birthDateField;
            }
            set
            {
                this.birthDateField = value;
                this.RaisePropertyChanged("BirthDate");
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BirthDateSpecified {
            get {
                return this.birthDateFieldSpecified;
            }
            set {
                this.birthDateFieldSpecified = value;
                this.RaisePropertyChanged("BirthDateSpecified");
            }
        }
    ...
