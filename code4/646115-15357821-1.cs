    private List<HyperlinkInfo> GetHyperlinkByCode()
    {
            TourInfoBusiness obj = new TourInfoBusiness();
            List<HyperlinkInfo> lst = new List<HyperlinkInfo>();
            lst = obj.GetAllHyperlink();
            //lst = lst.Select(x => x.Attraction).ToList();
            var k = lst.Select(x => x.Attraction).Distinct();
            return k.ToList();
    }
