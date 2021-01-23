    public static IEnumerable<int> QueryComplexXml()
    {
        var doc = XDocument.Parse(XML);
        if (doc.Root == null)
        {
            throw new System.InvalidOperationException("No root");
        }
        var mainFoo = doc.Root.Element("MainFoo");
        if (mainFoo == null)
        {
            throw new System.InvalidOperationException("No MainFoo");
        }
        var userIDs = from foo in mainFoo.Elements("Foo")
                      where
                          foo.Elements("Bar")
                             .Any(
                                 bar =>
                                 bar.Attribute("N").Value == "Education" &&
                                 bar.Attribute("V").Value == "Specific Text")
                      let user = foo.Element("User")
                      where user != null
                      select int.Parse(user.Attribute("ID").Value);
        return userIDs;
    }
