    HtmlAgilityPack.HtmlDocument hdoc = new HtmlAgilityPack.HtmlDocument();
    hdoc.LoadHtml("<Year>where 12 > 13 occures </Year>");
    using(StringWriter wr = new StringWriter())
    {
       using (XmlWriter xmlWriter = XmlWriter.Create(wr,
               new XmlWriterSettings() { OmitXmlDeclaration = true }))
       {
           hdoc.Save(xmlWriter);
           Console.WriteLine(wr.ToString());
       }
    }
    
