    var axe = elem.Descendants("NodeNumber1")
                   .Select(n => new
                   {
                       Name= n.Attribute("Name").Value,
                       MyObj= from o in n.Descendants("NodeChild")
                              select new
                              {
                                  var1= o.Descendants("var1").FirstOrDefault().Value,
                                  var2= o.Descendants("var2").FirstOrDefault().Value,
                              }
                   })
                   .First();
