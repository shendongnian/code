    XNamespace skos = XNamespace.Get("http://www.w3.org/2004/02/skos/core#");
    XNamespace geo = XNamespace.Get("http://www.geonames.org/ontology#");
    XNamespace rdfs = XNamespace.Get("http://www.w3.org/2000/01/rdf-schema#");
        
    XDocument rdf = XDocument.Load(new StringReader(xmlstr));
    foreach(var attr in rdf.Descendants(geo + "Country"))
    {
        Console.WriteLine(
            attr.Attribute(skos + "notation").Value + " "  + 
            attr.Attribute(rdfs + "label").Value );
    }
