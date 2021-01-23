        private bool? _myBool;
        [XmlIgnore]
        public bool? MyBool
        {
            get
            {
                return _myBool;
            }
            set
            {
                _myBool = value;
            }
        }
        [XmlAttribute("MyBool")]
        public string MyBoolstring
        {
            get
            {
                return MyBool.HasValue
                ? XmlConvert.ToString(MyBool.Value)
                : string.Empty;
            }
            set
            {
                MyBool =
                !string.IsNullOrEmpty(value)
                ? XmlConvert.ToBoolean(value)
                : (bool?)null;
            }
        }
