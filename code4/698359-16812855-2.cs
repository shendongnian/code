    var xDoc= XDocument.Load(Application.StartupPath+"\\load.xml");
    
    var userlist = xDoc.Descendants("users").Descendants("user")
                .Select(u => new {
                                    Username = u.Element("username").Value,
                                    Password = u.Element("password").Value
                                }).ToList();
