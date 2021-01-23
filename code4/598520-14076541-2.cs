    string text = "Some";
    var query = from foo in xdoc.Descendants("Foo")
                let user = foo.Element("User")
                where user != null &&
                      foo.Elements("Bar")
                         .Any(bar => (string)bar.Attribute("N") == "Education" &&
                                     !Regex.IsMatch((string)bar.Attribute("V"), text,
                                                    RegexOptions.IgnoreCase))
                select (int)user.Attribute("ID");
    // result: 2, 4
