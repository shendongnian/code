    var xml = @"<Contacts>
                        <Node>
                            <ID>123</ID>
                            <Name>ABC</Name>
                        </Node>
                        <Node>
                            <ID>124</ID>
                            <Name>DEF</Name>
                        </Node>
                </Contacts>";
    var xdoc = XDocument.Parse(xml);
    var namelist = xdoc.Descendants()
                        .Select(i => i.Name.ToString())
                        .Distinct()
                        .ToList();
