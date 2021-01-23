        [DataMember]
        public string Date { get; set; }
     
        [IgnoreDataMember]
        public DateTime? DateForInternalUse { get; set; }
    
        [OnSerializing]
        public void OnSerializing(StreamingContext context)
        {
          Date = (DateForInternalUse != null) ? ((DateTime)DateForInternalUse).ToString(DateTimeFormatForSerialization) : null;
        }
    
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
          try
          {
            DateForInternalUse = !String.IsNullOrEmpty(Date) ? DateTime.ParseExact(Date, DateTimeFormats, null, DateTimeStyles.None) : (DateTime?)null;
          }
          catch (FormatException)
          {
            DateForInternalUse = null;
          }
        }
