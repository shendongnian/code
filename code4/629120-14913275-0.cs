    static User GetUserFromXElement(string xml)
    {
        XElement temp = XElement.Parse(xml);
        User temp = new User();
        foreach (XElement inner in temp.Elements())
        {
            switch inner.Name
            {
                case "Name":
                    temp.Name = inner.Value
                    break;
                //whatever
            }
        }
    }
