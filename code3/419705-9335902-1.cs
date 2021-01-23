    XNamespace skos = XNamespace.Get("http://www.w3.org/2004/02/skos/core#");
    XNamespace geo = XNamespace.Get("http://www.geonames.org/ontology#");
    XNamespace rdfs = XNamespace.Get("http://www.w3.org/2000/01/rdf-schema#");
        
    XDocument rdf = XDocument.Load(new StringReader(xmlstr));
    foreach(var country in rdf.Descendants(geo + "Country"))
    {
        Console.WriteLine(
            country.Attribute(skos + "notation").Value + " "  + 
            country.Attribute(rdfs + "label").Value );
    }
