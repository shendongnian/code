    foreach (XElement p in doc.Descendants("Person"))
    {
        string name = (string)p.Attribute("firstName") + (string)p.Attribute("lastName");
        int age = (int)p.Attribute("age");
        p.RemoveAttributes();
        p.SetAttributeValue("isMale", IsMale(name));
        p.SetAttributeValue("name", name);
        p.SetAttributeValue("age", age);
        p.RemoveNodes();
    }
