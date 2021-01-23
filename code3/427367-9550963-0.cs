    string xml =
       @"<project>
            <user>
               <id>1</id>
               <name>a</name>
            </user>
            <user>
               <id>2</id>
               <name>b</name>
            </user>
         </project>";
    XElement x = XElement.Load(new StringReader(xml));
    x.Add(new XElement("user", new XElement("id",3),new XElement("name","c") ));
    string newXml = x.ToString();
