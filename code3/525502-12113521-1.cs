    [XmlRoot("Server")]
    public class RegisterServerObjectAdapter : RegisterServerObject
    {
        [XmlElement("GroupID")]
        public string GroupIDNew
        {
            get { return GroupID.ToString(); }
            set
            {
                int outInt;
                int.TryParse(value, out outInt);
                GroupID = outInt;
            }
        }
    }
