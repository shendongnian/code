        [XmlIgnore]
        public Field[][] Batch
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;
            }
        }
        [XmlArrayItemAttribute("ParameterEntry", IsNullable = false)]
        public Field[] BatchEntry
        {
            get
            {
                return _field.All(e => e is Field);
            }
        }
    
