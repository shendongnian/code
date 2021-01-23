    public List<Users> ElementsToUsers (string xml)
    {
        List<Users> usrsList = new List<Users>();
        XDocument temp = XDocument.Load(xml);
        foreach (XElement e in XDocument.Root.Elements())
        {
            usrsList.Append(Users.GetUserFromXElement(e));
        }
        return usrsList;
    }
