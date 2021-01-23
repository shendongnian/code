        [XmlRoot("Server")]
        public class RegisterServerObject
        {
            public RegisterServerObject() { }
            public int ServerID { get; set; }
            [XmlIgnore]
            public int GroupID { get; set; }
            [XmlElement(ElementName = "GroupID")]
            public string GroupIDStr
            {
                get
                {
                    return this.GroupID.ToString();
                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        this.GroupID = 0;
                    }
                    else
                    {
                        this.GroupID = int.Parse(value);
                    }
                }
            }
            public int ParentID { get; set; }
            public string ServerName { get; set; }
            public string User { get; set; }
            public int Uid { get; set; }
            public string Domain { get; set; }
            public string Location { get; set; }
            [XmlArray(ElementName = "AssociatedModules")]
            [XmlArrayItem(ElementName = "Module")]
            public List<RegisterModuleObject> AssociatedModules { get; set; }
        }
        public class RegisterModuleObject
        {
            public int ModId { get; set; }
            public int ServerId { get; set; }
            public string ModName { get; set; }
            public int ModuleStatus { get; set; }
        }
