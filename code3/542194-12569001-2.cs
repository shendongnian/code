    var query = from c in _context.MCTargets
                      where c.TargetDateFrom==d1 && c.TargetDateTo<=d2
                      group c by c.MarketingCampaignID into g
                      select new {
                          CampaignID = g.Key,
                          StartDate = d1,
                          EndDate = d2
                      };
    IEnumerable<MSReport> queryMSReports = from item in query.AsEnumerable()
                                           select new MSReport(item.CampaignID, item.StartDate, item.EndDate);
