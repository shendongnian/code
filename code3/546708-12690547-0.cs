    List<GrantAgresso> lsResult = (from g in xml.Element("root").Elements("Elementname")
        let yearNode = g.Element("yearnode")
        select new GrantAgresso
        {
             Year = string.IsNullOrWhiteSpace(yearNode.Value) ? 0 : int.Parse(yearNode.Value),
             Subdomain = g.Element("domainnode").Value
        }).ToList();
