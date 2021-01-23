    string _file=@"c:\sample.xml";
    XDocument doc;
    if (!File.Exists(_file))
    {
        doc = new XDocument();
        doc.Add(new XElement("Root"));
    }
    else
    {
        doc = XDocument.Load(_file);
    }
    doc.Root.Add(
          new XElement("data",
                       new XElement("CompanyCode","C101"),
                       new XElement("ProductCode","P101")
                ) 
          );
    doc.Save(_file);
