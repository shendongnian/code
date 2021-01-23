        /// <summary>
        /// Representations of the TimeStamp used for serialization
        /// </summary>
        [DataMember(Name = "TimeStamp")]
        private String timeStamp;
        /// <summary>
        /// timestamp when the request is sent
        /// </summary>
        [IgnoreDataMember]
        public DateTime TimeStamp
        {
            get { return DateTime.Parse(timeStamp, null, DateTimeStyles.RoundtripKind); }
            set { timeStamp = value.ToUniversalTime().ToString("o"); }
        }
