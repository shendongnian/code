        private DateTime? _lastUpdated;
        [XmlAttribute("lastUpdated")]
        public DateTime LastUpdated {
            get {
                return (DateTime)_lastUpdated;
            }
            set
            {
                _lastUpdated = value;
            }
        }
        public bool LastUpdatedSpecified
        {
            get
            {
                return _lastUpdated.HasValue;
            }
        }
