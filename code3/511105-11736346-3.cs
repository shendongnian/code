    public class Time{
        [XmlIgnore]
        public TimeSpan _duration;
        [XmlAttrubute(DataType = "duration")]
        public string value
            get
            {
                return XmlConvert.ToString(this._duration);
            }
            set
            {
                this._duration = XmlConvert.ToTimeSpan(value);
            }
        }
