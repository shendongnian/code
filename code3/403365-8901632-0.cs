    [XmlRootAttribute("FooClass")] 
    public class FooClass
    {
        private string _personalData;
        [NonSerialized()]
        public string PersonalData
        {
            set { _personalData = value;}
            get { return _personalData; }
        }
        [XmlAttribute("PersonalData")]
        public string PersonalDataEncrypted
        {
            set { _personalData = DecryptData(value);}
            get { return EncryptData(_personalData); }
        }
    }
