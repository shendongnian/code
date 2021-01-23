     using (var stream = new StringReader(xml))
           {
                XDocument xmlFile = XDocument.Load(stream);
    
                var query = (IEnumerable)xmlFile.XPathEvaluate("/data/item/parameter[@type='id']");
    
              foreach (var x in query.Cast<XElement>())
                 {
                     Console.WriteLine(  x.Value="2");
                 }
             
            }
