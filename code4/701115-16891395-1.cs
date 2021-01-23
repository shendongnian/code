    XmlDocument xmldoc = new XmlDocument();
    xmldoc.Load(@"D:\temp\contacts.xml");  // use the .Load() method - not .LoadXml() !!
    // get a list of all <Contact> nodes
    XmlNodeList listOfContacts = xmldoc.SelectNodes("/Contacts/Contact");
    // iterate over the <Contact> nodes
    foreach (XmlNode singleContact in listOfContacts)
    {
       // get the Profiles/Personal subnode
       XmlNode personalNode = singleContact.SelectSingleNode("Profiles/Personal");
       // get the values from the <Personal> node
       if (personalNode != null)
       {
          string firstName = personalNode.SelectSingleNode("FirstName").InnerText;
          string lastName = personalNode.SelectSingleNode("LastName").InnerText;
       }
       // get the <Email> nodes
       XmlNodeList emailNodes = singleContact.SelectNodes("Emails/Email");
       foreach (XmlNode emailNode in emailNodes)
       {
          string emailTyp = emailNode.SelectSingleNode("EmailType").InnerText;
          string emailAddress = emailNode.SelectSingleNode("Address").InnerText;
       }
    }
