    var res = (from x in lstDBDetails
                           group x by new { x.ServerId, x.Title,x.Address } into g
                           select new
                           {
                               ServerId = g.Key.ServerId,
                               Title = g.Key.Title,
                               Address = g.Key.Address,
                               B = g.ToList()
                           });
    
                var doc = new XDocument(
                    new XElement("DataBaseServers",
                        res.Select(x =>
                            new XElement("DataBaseServer",
                                 new XAttribute("id", x.ServerId),
                                 new XAttribute("title", x.Title),
                                 new XAttribute("address", x.Address),
                                     new XElement("DataBases",
                                         x.B.Select(y =>
                                         new XElement("database",
                                             new XAttribute("id", y.DBId),
                                             new XAttribute("name", y.DbName),
                                             new XAttribute("userID", y.UserId),
                                             new XAttribute("password", y.Password))))))));
