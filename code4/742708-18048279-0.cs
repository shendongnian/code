    var projectName = (string)xdocument.Root.Element("ProjectName");
    var webSites =  xdocument.Root.Element("ProjectToPost")
                        .Elements("Website")
                        .Select(w => new
                        {
                            ID = (int)w.Element("ID"),
                            Type = (string)w.Element("Type"),
                        })
                        .ToList();
