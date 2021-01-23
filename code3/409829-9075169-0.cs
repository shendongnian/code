    NL = System.Environment.NewLine;
    doc = XDocument.Parse(xml);
    StringBuilder output = new StringBuilder();
    
    var rounds = doc.Descendants("value");
    foreach(XElement round in rounds)
    {
      builder.Append(round.Attribute("value").Value + NL);
      foreach(XElement country in round.Elements())
      {
        builder.Append(country.Attribute("home").Value);
        builder.Append(" - ");
        builder.Append(country.Attribute("away").Value);
        builder.Append(" in ");
        builder.Append(country.Attribute("venue").Value);
        builder.Append(NL);
      }
    }
