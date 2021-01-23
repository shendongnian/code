    string uri = "> url here! <";
    System.Net.WebClient wc = new System.Net.WebClient();
    StreamReader sr = new StreamReader(wc.OpenRead(uri));
    string xml = sr.ReadToEnd();
    XElement rootElement = XElement.Parse(xml);
    string targetValue =
      (string)rootElement.Elements("Identifier")
      .Single(e => (string)e.Attribute("name") == "v")
      .Attribute("value");
