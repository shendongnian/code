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
