            [DataMember]
            private long timeStampLong;
    
            
            [IgnoreDataMember]
            public DateTime TimeStamp
            {
                get { return new DateTime(timeStampLong); }
                set { timeStampLong = value.Ticks; }
            }
    
