    [XMLArray("Users")]
    public class User
    {
        [XmlIgnore]
        public bool? m_copy;
        [XmlAttribute("copy")]
        public string copy
        {
            get { return (m_copy.HasValue) ? m_copy.ToString() : null; }
            set { m_copy = !string.IsNullOrEmpty(value) ? bool.Parse(value) : default(bool?); }
        }
    }
