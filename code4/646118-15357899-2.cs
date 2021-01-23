    private List<HyperlinkInfo> GetHyperlinkByCode()
    {
            TourInfoBusiness obj = new TourInfoBusiness();
            List<HyperlinkInfo> lst = obj.GetAllHyperlink();
            return lst.DistinctBy(x => x.Attraction).ToList();
    }
