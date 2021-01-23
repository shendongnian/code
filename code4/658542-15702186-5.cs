    var doc = System.Xml.Linq.XDocument.Load(YOUR XML FILE PATH);
    List<string> values = new List<string>();
    foreach (System.Xml.Linq.XElement item in doc.Descendants("Prijs"))
    {
         values.Add(item.Attribute("klasse").Value);
    }
    //textBlock1.Text = values[0];
    //textBlock2.Text = values[1];
    //textBlock3.Text = values[2];
