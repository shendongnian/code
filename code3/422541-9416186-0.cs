    var xml = @"<?xml version=""1.0""?>
    <Root>
        <Response ID=""xyx66860512"" PID=""13681839"" ERROR=""0"" STATUS=""5""/>
    </Root>";
    
    var doc = XDocument.Parse(xml);
    
    var element = doc.Root.Element("Response");
    var id = element.Attribute("ID").Value;
    var pid = Int32.Parse(element.Attribute("PID").Value);
    var error = element.Attribute("ERROR").Value;
    var status = element.Attribute("STATUS").Value;
