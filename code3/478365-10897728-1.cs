    var it = db.Descendants("app")
                        .OrderBy(app => app.Attribute("name").Value)
                        .Select(app => new Apps() {
                            Name = app.Attribute("name").Value,
                            Logs = app.Descendants("log").Select(a =>
                                new Logs() {
                                    Name = a.Attribute("name") != null ? a.Attribute("name").Value : null,
                                    Path = a.Attribute("path") != null ? a.Attribute("path").Value : null,
                                    Filename = a.Attribute("filename") != null ? a.Attribute("filename").Value : null
                                }).ToList()
                        }).ToList();
