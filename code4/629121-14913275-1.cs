    public string UsersToElements (List<Users> toWrite)
    {
        Stringbuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        XElement root = new XElement("root");
        XDocument temp = new XDocument(root);
        foreach (User user in toWrite)
        {
            root.Append(user.GetXElement());
        }
        temp.Save(sw);
        return sw.ToString();
    }
