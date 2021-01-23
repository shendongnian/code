    string xml1 = @"
        <RPM>
            <CAI ID=""101"" Name=""Guaranteed Payments""/>
            <CAI ID=""102"" Name=""Sports Recreation""/> 
        </RPM>";
    string xml2 = @"
        <RPM>
            <CAI ID=""102"" Active=""False""/>
            <CAI ID=""103"" Active=""True""/> 
        </RPM>";
    XDocument xDoc1 = XDocument.Load(new StringReader(xml1));
    XDocument xDoc2 = XDocument.Load(new StringReader(xml2));
    var cais = xDoc1.Descendants("CAI")
              .Concat(xDoc2.Descendants("CAI"))
              .GroupBy(x => x.Attribute("ID").Value)
              .Select(x => x.SelectMany(y => y.Attributes()).DistinctBy(a => a.Name))
              .Select(x => new XElement("CAI", x));
    string xml = new XElement("RPM", cais).ToString();
