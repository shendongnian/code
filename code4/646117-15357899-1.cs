    private List<HyperlinkInfo> GetHyperlinkByCode()
    {
            TourInfoBusiness obj = new TourInfoBusiness();
            List<HyperlinkInfo> lst = obj.GetAllHyperlink();
            return lst.GroupBy(x => x.Attraction) // group links by attraction
                      .Select(g => g.First()) // select first link from each group
                      .ToList(); // convert result to list
    }
