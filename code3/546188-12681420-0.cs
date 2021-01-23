    [XmlIgnore]
        public DateTime? start_timestamp { get; set; }
        [XmlElement("start-timestamp")]
        public string start_timestampstring
        {
            get
            {
                return start_timestamp.HasValue ? start_timestamp.Value.ToString("ddd MMM dd HH:mm:ss zzz yyyy") : string.Empty;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    try
                    {
                        start_timestamp = DateTime.ParseExact(value, "ddd MMM dd HH:mm:ss zzz yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        start_timestamp = null;
                    }
                }
                else
                {
                    start_timestamp = null;
                }
            }
        }
