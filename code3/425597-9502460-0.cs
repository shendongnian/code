    public static College Deserialize(XElement collegeXML)
    {
        return new College()
               {
                   Name = (string)collegeXML.Element("Name"),
                   Address = (string)collegeXML.Element("Address"),
                   Persons = (from personXML in collegeXML.Element("Persons").Elements("Person")
                              select Person.Deserialize(personXML)).ToList()
               }
    }
    public static XElement Serialize(College college)
    {
        return new XElement("College",
                   new XElement("Name", college.Name),
                   new XElement("Address", college.Address)
                   new XElement("Persons", (from p in college.Persons
                                            select Person.Serialize(p)).ToList()));
    );
