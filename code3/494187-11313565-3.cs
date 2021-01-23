    select new CampaignEmailReportLinksViewModel
                                {
                                    LinkURL = g.Key.URL,
                                    QtyClicks = g.Count(),
                                    Clickers = ""
                                }
    
    foreach(var item in items){
        item.Clickers = db.CampaignLinkClicks
                               .Where(x=>x.Url == item.URL)
                               .Clickers.Select(x=>x.Name).ToString();
    }
