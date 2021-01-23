    public class OtherInfo
    {
        [XmlIgnore]
        public string Info1 { get; set; }
        [XmlIgnore]
        public string Info2 { get; set; }
        [XmlText]
        public string InfoString
        {
            get
            {
                return String.Format("{0}:{1}", this.Info1, this.Info2);
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    return;
                var infos = value.Split(':');
                if (infos.Length < 2)
                    return;
                this.Info1 = infos[0];
                this.Info2 = infos[1];
            }
        }
    }
