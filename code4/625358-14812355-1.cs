    class GroupName
    {
        public string Name { get; set; }
    
        public override string ToString()
        {
            return this.Name;
        }
    
        // Specific conversion from string to GroupName object
        public static implicit operator GroupName(string s)
        {
            return new GroupName() { Name = s };
        }
    }
    public PhoneBook Rebuild()
    {
        using (XmlReader reader = XmlReader.Create(path))
        {
            // read to the start of the xml
            reader.MoveToContent();
            // create the return object
            PhoneBook returnObject = new PhoneBook();
            returnObject.Items = new List<PhoneBookGroup>();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // read each GroupName Node as a separate node collection
                    if (reader.Name == "GroupName")
                    {
                        // This is the root node of the groups
                        PhoneBookGroup grp = null;
                        Contact currentContact = null;
                        // loop the reader from this starting node
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                switch (reader.Name)
                                {
                                    case "GroupName":
                                        if (grp == null)
                                        {
                                            grp = new PhoneBookGroup();
                                            returnObject.Items.Add(grp);
                                            // must implement an implicit operator between string and GroupName object
                                            grp.Name = (GroupName)reader.ReadElementString();
                                        }
                                        else
                                        {
                                            // start of a new group, so null what we have so far and start again
                                            grp = null;
                                        }
                                        break;
                                    case "Addres":
                                        // Address is the start node for a contact so create a new contact and start filling it
                                        currentContact = new Contact();
                                        if (grp.Items == null)
                                        {
                                            grp.Items = new List<Contact>();
                                        }
                                        grp.Items.Add(currentContact);
                                        // due to the way the xml is being written the value is held as the namespace !!!
                                        currentContact.Address = reader.NamespaceURI;
                                        break;
                                    case "Number":
                                        // due to the way the xml is being written the value is held as the namespace !!!
                                        currentContact.Phone = reader.NamespaceURI;
                                        break;
                                    case "Name":
                                        // due to the way the xml is being written the value is held as the namespace !!!
                                        currentContact.Name = reader.NamespaceURI;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            return returnObject;
    }
