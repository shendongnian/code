        public class SetupXml
        {
            public SetupXml()
            {
                SubSetups = new Collection<SubSetupXml>();
            }
    
            [XmlIgnore]
            public Collection<SubSetupXml> SubSetups { get; private set; }
    
            [EditorBrowsable(EditorBrowsableState.Never)]
            [GeneratedCodeAttribute("Whatever", "1.0.0.0")]
            [XmlArray("subSetups")]
            [XmlArrayItem("subSetup")]          
            public SubSetupXml[] SerializationSubSetups
            {
                get
                {
                    return SubSetups.ToArray();
                }
                get
                {
                    SubSetups = new SubSetups();
                    if (value != null)
                    {
                        foreach(SubSetupXml ssx in value)
                        {
                            SubSetups.Add(ssx);
                        }
                    }
                }
            }
        }
