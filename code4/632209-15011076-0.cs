    [Serializable]
    [XmlRoot("oneshot")]
    public class LeaveRequestPush : IXmlSerializable
    {
        public string FormNamespace { get; set; }
        public int Days { get; set; }
        public string LeaveType { get; set; }
        #region IXmlSerializable
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("dm", "form_namespace", "http://mobileforms.devicemagic.com/xforms", FormNamespace);
            writer.WriteElementString("Days", Days.ToString());
            writer.WriteElementString("Leave_Type", LeaveType);
        }
    }
    public void ReadXml (XmlReader reader)
    {
        // populate from xml blob
    }
    public XmlSchema GetSchema()
    {
        return(null);
    }
