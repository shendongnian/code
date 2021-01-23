    select new CampaignEmailReportLinksViewModel
                                {
                                    LinkURL = g.Key.URL,
                                    QtyClicks = g.Count(),
                                    Clickers = ""
                                }
    
    foreach(var result in results){
        result.Clickers = db.CampaignLinkClicks
                               .Where(x=>x.Url == result.URL)
                               .Clickers.Select(x=>x.Name).ToString();
    }
