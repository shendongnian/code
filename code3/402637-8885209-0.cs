    [XmlRoot]
    public class X
    {
        [XmlIgnore]
        public decimal Dec { get; set; }
    
        [XmlElement("Dec")]
        public string DecString
        {
            get
            {
                return Dec.ToString("F2", CultureInfo.InvariantCulture);
            }
            set
            {
                Dec = decimal.Parse(value, CultureInfo.InvariantCulture);
            }
        }
    }
