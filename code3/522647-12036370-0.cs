        [XmlArrayItem("Skill", typeof(Skill), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlArray("SkillSummary", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Skill[] Skills
        {
          get;
          set;
        }
        [XmlArray("ContactPropertySummary")]
        [XmlArrayItem("ContactProperty", typeof(ContactProperty), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ContactProperty[] Properties
        {
          get;
          set;
        }
        [XmlArray("GroupSummary", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Group", typeof(Group), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Group[] Groups
        {
          get;
          set;
        }
