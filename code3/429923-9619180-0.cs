    public class gdEvent : IXmlSerializable
    {
        private DateTime _startTime;
        private DateTime _endTime;
    
        public gdEvent(DateTime startTime, DateTime endTime)
        {
            _startTime = startTime;
            _endTime = endTime;
        }
    
        public gdEvent()
        {
            _startTime = DateTime.MinValue;
            _endTime = DateTime.MinValue;
        }
    
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        public void WriteXml(XmlWriter writer)
        {
            if (_startTime != DateTime.MinValue)
                writer.WriteAttributeString("startTime", _startTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            if (_endTime != DateTime.MinValue)
                writer.WriteAttributeString("endTime", _endTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }
    
        public void ReadXml(XmlReader reader)
        {
            string startTimeString = reader.GetAttribute("startTime");
            if (!string.IsNullOrEmpty(startTimeString))
            {
                _startTime = DateTime.Parse(startTimeString);
            }
            string endTimeString = reader.GetAttribute("startTime");
            if (!string.IsNullOrEmpty(endTimeString))
            {
                _endTime = DateTime.Parse(endTimeString);
            }
        }
}
