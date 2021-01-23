        [NonSerialized]
        public DateTime MyDate { get; set; }
        [System.Xml.Serialization.XmlAttribute("MyDate")]
        public string MyDateString
        {
            get
            {
                if (MyDate.Equals(DateTime.MinValue))
                {
                    return string.Empty;
                }
                else
                {
                    return MyDate.ToShortDateString();
                }
            }
            set
            {
                DateTime dtTemp = DateTime.MinValue;
                if (DateTime.TryParse(value, out dtTemp))
                {
                    MyDate = dtTemp;
                }
                else
                {
                    MyDate = DateTime.MinValue;
                }
            }
        }
