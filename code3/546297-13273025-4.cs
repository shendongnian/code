    [Serializable]
    public class SendCodeResult
    {
        string code;
        [XmlElement(Type = typeof(string), ElementName = "Code")]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
    }
