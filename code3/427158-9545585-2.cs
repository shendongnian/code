    var xDocument = new XDocument(
        new XElement("root", 
            new XElement("System", 
                new XElement("OS",
                    new XElement("Ver", Environment.OSVersion.ToString()), 
                    new XElement("Execute_Bit_Length", "64"),
                    new XElement("Registry_version", b) 
    
                    ),
                new XElement("APPCHECK",
                    new XElement("NET_Framework_4", NET_FRAMEWORK),
                    new XElement("PDF_Reader", PDF_READ),
                    new XElement("Internet_Explorer_Version", IE)
                )
            )));
    xDocument.Save("sys_info.xml");
