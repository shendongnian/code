    var xmlDoc = XDocument.Parse(myXmlString);
    var exprs = xmlDoc.Descendants("EXPR");
    var conversions = xmlDoc.Descendants("CONVERSION");
    var structuredInfo = exprs.Zip(conversions, Tuple.Create)
       .Select(info => new { 
               Expr = info.Item1.Value, 
               Date = info.Item2.Element("DATE").Value,
               Ask = info.Item2.Element("ASK").Value
     });
