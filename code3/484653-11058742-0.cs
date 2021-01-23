    var root = XDocument.Load(@"...").Root;
    var ns = root.GetDefaultNamespace();
    var users = root.Descendants(ns.GetName("default")).Where(e => e.Attribute("property").Value == "UserName").Select(e => new
    {
        Type = e.Parent.Attribute("type").Value,
        UserName = e.Attribute("value").Value
    });
    Console.WriteLine(String.Join(Environment.NewLine, users.Select(u => String.Format("{0} ({1})", u.UserName, u.Type))));
