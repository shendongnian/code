        private string _recordId;
        [DataMember]
        public String RecordId
        {
            get { return _recordId ?? (_recordId = Guid.NewGuid().ToString()); }
            set { _recordId = value; }
        }
