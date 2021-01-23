    var result = xmlDoc.Descendants("myobject")
                    .Select(m => new
                    {
                        Property1 = m.Attribute("property1").Value,
                        Property2 = m.Attribute("property2").Value,
                        Property3 = m.Descendants("property3").Select(p3=>p3.Value).ToList()
                    })
                    .ToList();
