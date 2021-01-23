    string xml = @"<categories>
                    <category>
                    <id>1</id>
                    <name>Computer</name>
                    <description>Information tech.</description>
                    <active>False</active>
                    </category>
                    <category>
                    <id>2</id>
                    <name>Cate1</name>
                    <description>MMukh</description>
                    <active>True</active>
                    </category>
                </categories>";
               
    XDocument xDoc = XDocument.Parse(xml);
    int id = 1;
    
    var items = xDoc.XPathSelectElement("//category[id=" + id + "]")
                .Elements()
                .ToDictionary(e => e.Name.LocalName, e => (string)e);
    
    if (items != null)
    {
        // display these fields to the text box
        Console.WriteLine(items["name"]);
        Console.WriteLine(items["description"]);
        Console.WriteLine(items["active"]);
    }
