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
                List<Field> OneDimFields = new List<Field>();
                foreach(Field[] field in _field)
                {
                    OneDimFields.AddRange(field);
                }
                return OneDimFields.ToArray(); 
            }
        }
    
