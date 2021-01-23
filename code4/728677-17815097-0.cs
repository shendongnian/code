     if (xmlDoc.Descendants("a").Count() > 0)
       {
         var afIds = (from af in xmlDoc.Descendants("af")
                     from attribute in af.Attributes("Id")
                     select attribute.Value).Distinct(StringComparer.Ordinal).ToList();
    
         var loContainers = xmlDoc.Descendants("a").Select(a => 
                        new {element = a, afids = a.Descendants("x").Attributes("afId") });
    
         foreach (var container in loContainers)
         {
           foreach (var afId in afIds.Where(afId => !container.afids.Any(attr => afId.Equals(attr.Value))))
           {
              container.element.Add(new XElement("x", new XAttribute("afId", afId),
                                new XElement("Paragraphs",
                                    new XElement("Paragraph",
                                        new XAttribute("AllowSelection", "false"),
                                        new XElement("Text"),
                                        new XElement("Content")))));
                 break;
             }
          }
    
          foreach (var afId in afIds)
          {
            var distinctlearningObjs = from x in xmlDoc.Descendants("x").Where(
                                x => (string)x.Attribute("afId").Value == afId).GroupBy(
                                    x => x.Attribute("afId").Value)
                          select new { MaxParaCount = x.Max(y => y.Descendants("Paragraph").Count ()) };
    
             foreach (var x in distinctlearningObjs)
             {
                var docLos = from doclo in xmlDoc.Descendants("x").Where(
                                    x => (string)x.Attribute("afId").Value == afId)
                            select new { doclo,  element = doclo.Element("Paragraphs"),
                                        count = doclo.Descendants("Paragraph").Count()
                            };
    
                 foreach (var docLo in docLos)
                 {
                    var paraCount = docLo.count;
                    var maxCount = x.MaxParaCount;
    
                    for (var i = paraCount; i < maxCount; i++)
                    {
                       docLo.element.Add(new XElement("Paragraph",
                                        new XAttribute("AllowSelection", "false"),
                                        new XElement("Text"),
                                        new XElement("Content")));
                     }
                  }
               }
             }
          }
