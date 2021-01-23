    var doc1 = XDocument.Load(infile1);
    var doc2 = XDocument.Load(infile2);
    var dict =  doc1.Root.Elements("Event").ToDictionary(el => 
        el.Attribute("id").Value);
    doc2.Root.Elements("Event").ToList().ForEach(el => {
        XElement el2;
        if (dict.TryGetValue(el.Attribute("id").Value, out el2) &&
            !el.Attributes().Select(a => new { a.Name, a.Value }).Except(
            el2.Attributes().Select(a => new { a.Name, a.Value })).Any()) 
                el.Remove(); 
    });
    doc2.Save(outfile);
